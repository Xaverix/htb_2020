using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardEntry : MonoBehaviour
{
    public TextMeshProUGUI position;
    public TextMeshProUGUI nick;
    public TextMeshProUGUI score;

    public void SetEntry(int pos, string nick, string score)
    {
        position.text = pos.ToString();
        this.nick.text = nick;
        this.score.text = score;
    }
}
