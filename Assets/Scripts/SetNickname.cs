using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetNickname : MonoBehaviour
{
    private string _letters = " ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    private int _currentLetter;

    public static string nickname;
    public RectTransform arrows;
    public TextMeshProUGUI nicknamePreview;
    public bool _nicknameSet;

    private void Awake()
    {
        nickname = "";
        nicknamePreview.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (_nicknameSet)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_currentLetter == 0)
            {
                _currentLetter =_letters.Length - 1;
            }
            else
            {
                _currentLetter -= 1;
            }
            
            nicknamePreview.text = nickname + _letters[_currentLetter];
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_currentLetter == _letters.Length - 1)
            {
                _currentLetter = 0;
            }
            else
            {
                _currentLetter += 1;
            }

            nicknamePreview.text = nickname + _letters[_currentLetter];
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_letters[_currentLetter] != _letters[0])
            {
                nickname += _letters[_currentLetter];
                _currentLetter = 0;
            }
            else
            {
                _nicknameSet = true;
                transform.parent.gameObject.SetActive(false);
                Debug.Log("Nickname: " + nickname);
                GameController.isStarted = true;
            }
        }
        
        arrows.anchoredPosition = new Vector2(70f * nickname.Length, 0f);
    }
    
    
}
