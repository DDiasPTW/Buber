using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    public float howLongTillNextChallenge;
    public GameObject challengeUI;
    public Text challengeText;
    public int minChallengeTimeSecs = 240, maxChallengeTimeSecs = 600;
    private int newChallenge;

    public List<string> Challenges = new List<string>();

    private void Awake()
    {
        challengeUI.SetActive(false);
        if (PlayerPrefs.GetInt("Challenges") == 1)
        {
            howLongTillNextChallenge = Random.Range(minChallengeTimeSecs, maxChallengeTimeSecs);
        }
        newChallenge = Random.Range(0, Challenges.Count);
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Challenges") == 1)
        {
            howLongTillNextChallenge -= Time.deltaTime;
            if (howLongTillNextChallenge <= 0)
            {               
                challengeUI.SetActive(true);
                challengeText.text = Challenges[newChallenge];
            }
        }       
    }

    public void CloseChallenge()
    {
        challengeUI.SetActive(false);
        howLongTillNextChallenge = Random.Range(minChallengeTimeSecs, maxChallengeTimeSecs);
        newChallenge = Random.Range(0, Challenges.Count);
    }
}
