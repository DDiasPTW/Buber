using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengesOnOff : MonoBehaviour
{
    public Text challengeTextOn_off;
    private void Awake()
    {
        PlayerPrefs.GetInt("Challenges", 1);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Challenges") == 0)
        {
            challengeTextOn_off.text = "Off";
        }else challengeTextOn_off.text = "On";
    }
    public void ChangePrefabChallenges()
    {
        if (PlayerPrefs.GetInt("Challenges") == 0)
        {
            PlayerPrefs.SetInt("Challenges", 1);
        }else if (PlayerPrefs.GetInt("Challenges") == 1)
        {
            PlayerPrefs.SetInt("Challenges", 0);
        }
    }
}
