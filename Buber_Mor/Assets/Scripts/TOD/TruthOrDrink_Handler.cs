using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TruthOrDrink_Handler : MonoBehaviour
{
    //Listas que vao segurar os TODs
    [SerializeField] private List<string> questions = new List<string>();
    [SerializeField] private List<string> _questions_ = new List<string>();

    //Lista que vai segurar o nome dos jogadores
    public List<string> _players = new List<string>();


    //Menu de adicionar os jogadores
    public GameObject add_Players_Menu;
    public GameObject nameHolder;

    //Sitio onde se escreve o nome dos jogadores
    private List<InputField> temporaryHolder = new List<InputField>();

    //Local onde se encontra o ficheiro que contem os TODs
    [SerializeField] private TextAsset TODQuestions;
    //private static string TODCSVPath = "/Scripts/TOD/TOD_Questions.csv";

    //Challenge Manager -> serve para pausar o timer de challenges
    private GameObject cM; 

    //Que lista esta a usar
    public bool using1 = true, using2 = false;

    //O texto dos TODs
    public Text questionText;
    public Text PlayerText;

    //Texto que aparece antes do jogo iniciar
    [Multiline]
    public string begginingText;

    //Que TOD e escolhido
    private int randomNumber;

    //Que jogador e escolhido
    private int randomPlayer;
    private void Awake()
    {
        add_Players_Menu.SetActive(true);
        questionText.text = begginingText;
        PlayerText.text = "";
        using1 = true;
        using2 = false;
        TODQuestions = Resources.Load<TextAsset>("TOD_Questions");
        GenerateTODS();
    }

    private void Start()
    {     
        cM = GameObject.FindGameObjectWithTag("CHALLENGE");
        cM.SetActive(false);
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
                randomPlayer = Random.Range(0,_players.Count);
                PlayerText.text = _players[randomPlayer].ToUpper();
                questionText.text = questions[randomNumber];
                _questions_.Add(questions[randomNumber]);
                questions.Remove(questions[randomNumber]);
            }
            if (using2)
            {
                randomNumber = Random.Range(0, _questions_.Count);
                randomPlayer = Random.Range(0, _players.Count);
                PlayerText.text = _players[randomPlayer].ToUpper();
                questionText.text = _questions_[randomNumber];
                questions.Add(_questions_[randomNumber]);
                _questions_.Remove(_questions_[randomNumber]);
            }
        } else questionText.text = "Please add a player".ToUpper();
        
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GenerateTODS()
    {
        string[] allTOD = TODQuestions.text.Split("\n" [0]);
       
        foreach (string uncas in allTOD)
        {          
            if (uncas != string.Empty)
            {
                questions.Add(uncas);
            }
        }
    }

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
}
