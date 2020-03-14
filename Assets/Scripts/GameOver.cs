using System;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;

    public Transform entryParent;
    public GameObject entryPrefab;
    
    private void OnEnable()
    {
        gameOverText.text = "Good job " + SetNickname.nickname + "!\nBut is score of " + GameController.score + " points enough to save the world?";
        StartCoroutine(GetLeaderboard());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SendScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", SetNickname.nickname);
        form.AddField("score", GameController.score);
 
        UnityWebRequest www = UnityWebRequest.Post("http://vps.bloodystation.com:1337/api/1.0/setScore", form);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
            
            Dictionary<string,object> dict = Json.Deserialize(www.downloadHandler.text) as Dictionary<string,object>;

            string status = dict["status"] as string;
            
            Debug.Log(www.downloadHandler.text);
        }
    }

    IEnumerator GetLeaderboard()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://vps.bloodystation.com:1337/api/1.0/getLeaderboard");
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
            
            Dictionary<string,object> dict = Json.Deserialize(www.downloadHandler.text) as Dictionary<string,object>;
            Dictionary<string, object> content = dict["content"] as Dictionary<string, object>;
            List<object> players = content["players"] as List<object>;

            for (int i = 0; i < players.Count; i++)
            {
                Dictionary<string, object> player = players[i] as Dictionary<string, object>;
                Instantiate(entryPrefab, entryParent).GetComponent<LeaderboardEntry>().SetEntry(i, player["username"] as string, player["score"] as string);
            }
            
            string status = dict["status"] as string;
            
            Debug.Log(www.downloadHandler.text);
        }
    }
}
