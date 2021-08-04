using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    //Tempo ate ao proximo desafio
    public float howLongTillNextChallenge;

    //O UI dos desafios + o texto
    public GameObject challengeUI;
    public Text challengeText;
    //
    private bool isChallenge;
    //Tempo minimo e maximo entre cada desafio (em segundos)
    public int minChallengeTimeSecs = 150, maxChallengeTimeSecs = 600;

    //Qual challenge vai ser escolhido (ao calhas)
    private int newChallenge;

    //Local onde esta o ficheiro com os challenges
    [SerializeField] private TextAsset ChallengesCSV;
    private static string ChallengeCSVPath = "/Scripts/NHIE/Challenges.csv";

    //Os desafios
    [SerializeField] private List<string> Challenges = new List<string>();

    private void Awake()
    {
        ChallengesCSV = Resources.Load<TextAsset>("Challenges");
        GenerateChallenges();
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
                isChallenge = true;               
            }
        }

        if (isChallenge)
        {
            challengeUI.SetActive(true);
            challengeText.text = Challenges[newChallenge];          
        }
    }

    public void GenerateChallenges()
    {
        //string[] allLines = File.ReadAllLines(Application.dataPath + ChallengeCSVPath);
        string[] allLines = ChallengesCSV.text.Split("\n"[0]);
        foreach (string uncas in allLines)
        {
            if (uncas != "")
            {
                Challenges.Add(uncas);
            }
        }
    }

    public void CloseChallenge()
    {
        challengeUI.SetActive(false);

        if (isChallenge)
        {
            isChallenge = false;
            howLongTillNextChallenge = Random.Range(minChallengeTimeSecs, maxChallengeTimeSecs);
            newChallenge = Random.Range(0, Challenges.Count);
        }
        
    }
}
