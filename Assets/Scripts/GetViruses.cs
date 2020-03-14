using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using UnityEngine;
using UnityEngine.Networking;

public class GetViruses : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoginUser());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");
 
        UnityWebRequest www = UnityWebRequest.Get("http://vps.bloodystation.com:1337/api/1.0/getViruses");
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
            
            Dictionary<string,object> dict = Json.Deserialize(www.downloadHandler.text) as Dictionary<string,object>;

            string status = dict["status"] as string;
            Dictionary<string, object> content = dict["content"] as Dictionary<string, object>;
            
            Debug.Log("Status: " + status);

            List<object> viruses = content["viruses"] as List<object>;
            foreach (var virus in viruses)
            {
                Debug.Log(virus as string);
            }
        }
    }
}
