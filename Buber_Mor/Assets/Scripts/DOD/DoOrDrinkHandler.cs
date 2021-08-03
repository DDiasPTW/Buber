using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoOrDrinkHandler : MonoBehaviour
{
    public List<string> questions = new List<string>();
    public List<string> _questions_ = new List<string>();
    public List<string> _players = new List<string>();

    public GameObject add_Players_Menu;
    public GameObject nameHolder;

    private List<InputField> temporaryHolder = new List<InputField>();

    public bool using1 = true, using2 = false;

    public Text questionText;

    private static string DODCSVPath = "/Scripts/DOD/DOD_Questions.csv";

    [Multiline]
    public string begginingText;

    private int randomNumber;
    private int randomPlayer;
    private void Awake()
    {
        add_Players_Menu.SetActive(true);
        questionText.text = begginingText;
        using1 = true;
        using2 = false;

        GenerateUncas();
    }

    public void GenerateUncas()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + DODCSVPath);
        foreach (string uncas in allLines)
        {
            questions.Add(uncas);
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
                questionText.text = _players[randomPlayer].ToUpper() + ": " + questions[randomNumber];
                _questions_.Add(questions[randomNumber]);
                questions.Remove(questions[randomNumber]);
            }
            if (using2)
            {
                randomNumber = Random.Range(0, _questions_.Count);
                randomPlayer = Random.Range(0, _players.Count);
                questionText.text = _players[randomPlayer].ToUpper() + ": " + _questions_[randomNumber];
                questions.Add(_questions_[randomNumber]);
                _questions_.Remove(_questions_[randomNumber]);
            }
        }
        else questionText.text = "Please add a player".ToUpper();

    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void AddPlayers()
    {
        add_Players_Menu.SetActive(true);
        _players.Clear();
        temporaryHolder.Clear();
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
        add_Players_Menu.SetActive(false);
    }
}
