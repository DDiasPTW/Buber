using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoOrDrinkHandler : MonoBehaviour
{
    //Listas que vao segurar os DODs
    [SerializeField] private List<string> questions = new List<string>();
    [SerializeField] private List<string> _questions_ = new List<string>();
    //numero total de DODs
    [SerializeField]private int numTotal;
    [SerializeField]private int numUp1;
    [SerializeField]private int numUp2;
    //Lista que vai segurar os nomes dos jogadores
    public List<string> _players = new List<string>();

    //Menu de adicionar os jogadores
    public GameObject add_Players_Menu;
    public GameObject nameHolder;

    //Sitio onde se vai escrever os nomes dos jogadores
    private List<InputField> temporaryHolder = new List<InputField>();

    //Que lista esta a ser usada
    public bool using1 = true, using2 = false;

    //Challenge manager -> serve para anunciar 'Up the stakes' e pausar o timer dos challenges
    private GameObject cM;

    //Texto dos DODs
    public Text questionText;

    //Local onde esta o ficheiro que contem os DODs
    //private static string DODCSVPath = "/Scripts/DOD/DOD_Questions.csv";
    [SerializeField] private TextAsset DODcvs;

    //Texto que aparece antes do jogo ser iniciado
    [Multiline]
    public string begginingText;

    //Que DOD e escolhido
    private int randomNumber;
    //Que player e escolhido
    private int randomPlayer;

    private void Awake()
    {
        DODcvs = Resources.Load<TextAsset>("DOD_Questions");
        add_Players_Menu.SetActive(true);
        questionText.text = begginingText;
        using1 = true;
        using2 = false;

        GenerateDODS();
        numTotal = questions.Count;
    }

    private void Start()
    {
        cM = GameObject.FindGameObjectWithTag("CHALLENGE");
        cM.SetActive(false);
        numUp1 = (numTotal / 3) * 2;
        numUp2 = numTotal / 3;
    }

    #region Do's Manager
    public void GenerateDODS()
    {
        string[] allLines = DODcvs.text.Split("\n"[0]); ;
        //string[] allLines = File.ReadAllLines(Application.persistentDataPath + DODCSVPath);
        foreach (string uncas in allLines)
        {
            if (uncas != "")
            {
                questions.Add(uncas);
            }
        }
    }
    public void Next()
    {
        //Serve para o botao 'next' -> vai a list e escolhe ao random uma das perguntas.
        //Se uma pergunta ja estiver a ser usada guarda-se essa pergunta numa nova list
        //e remove-se da original para nao haver repeticoes, depois caso a list
        //original estiver vazia usa-se a secundaria

        if (questions.Count == 0 && using1)
        {
            using1 = false;
            using2 = true;
        }
        else if (_questions_.Count == 0 && using2)
        {
            using2 = false;
            using1 = true;
        }

        if (_players.Count > 0)
        {
            if (using1)
            {
                randomNumber = Random.Range(0, questions.Count);
                randomPlayer = Random.Range(0, _players.Count);
                numTotal--;
                questionText.text = _players[randomPlayer].ToUpper() + ": " + questions[randomNumber];
                _questions_.Add(questions[randomNumber]);
                questions.Remove(questions[randomNumber]);
            }
            if (using2)
            {
                numTotal--;
                randomNumber = Random.Range(0, _questions_.Count);
                randomPlayer = Random.Range(0, _players.Count);
                questionText.text = _players[randomPlayer].ToUpper() + ": " + _questions_[randomNumber];
                questions.Add(_questions_[randomNumber]);
                _questions_.Remove(_questions_[randomNumber]);
            }
            UpStakes();
        }
        else questionText.text = "Please add a player".ToUpper();

    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void UpStakes()
    {
        if (numTotal == numUp1)
        {
            //raise stakes by one
            cM.GetComponent<ChallengeManager>().challengeText.text = "LET'S UP THE STAKES, THE AMOUNT YOU HAVE TO DRINK IS NOW DOUBLE THE ORIGINAL AMOUNT";
            cM.GetComponent<ChallengeManager>().challengeUI.SetActive(true);
        }
        else if (numTotal == numUp2)
        {
            //raise stakes twice
            cM.GetComponent<ChallengeManager>().challengeText.text = "LET'S UP THE STAKES, THE AMOUNT YOU HAVE TO DRINK IS NOW TRIPLE THE ORIGINAL AMOUNT";
            cM.GetComponent<ChallengeManager>().challengeUI.SetActive(true);
        }
    }
    #endregion


    #region AddPlayers
    public void AddPlayers()
    {
        add_Players_Menu.SetActive(true);
        _players.Clear();
        temporaryHolder.Clear();
        cM.SetActive(false);
    }

    public void ClosePlayers()
    {
        for (int i = 0; i < nameHolder.transform.childCount; i++)
        {
            InputField inputs = nameHolder.transform.GetChild(i).GetComponent<InputField>();
            temporaryHolder.Add(inputs);
        }

        foreach (InputField inputs in temporaryHolder)
        {
            if (inputs.text.Length > 0)
            {
                _players.Add(inputs.text);
            }
            else continue;
        }
        cM.SetActive(true);
        add_Players_Menu.SetActive(false);
    }

    #endregion
}
