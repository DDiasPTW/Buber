using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MLT_Handler : MonoBehaviour
{
    //Listas que vao segurar os MLTs
    [SerializeField]
    private List<string> nuncaUncas = new List<string>();
    [SerializeField]
    private List<string> _nuncaUncas_ = new List<string>();

    //Local onde esta o ficheiro que contem todos os MLTs
    //private static string MLTCSVPath = "/Scripts/MLT/MLT_Questions.csv";
    [SerializeField] private TextAsset MLTcvs;

    //Que lista esta a ser usada
    public bool using1 = true, using2 = false;

    //Texto dos MLTs
    public Text nuncaUncaText;

    //Texto que aparece antes do jogo comecar
    [Multiline]
    public string begginingText;

    //Numero random para escolher um MLT ao calhas
    private int randomNumber;
    private void Awake()
    {
        MLTcvs = Resources.Load<TextAsset>("MLT_Questions");
        using1 = true;
        using2 = false;
        GenerateMLT();
    }
    private void Start()
    {
        nuncaUncaText.text = begginingText;
    }

    public void NextUnca()
    {
        //Serve para o botao 'next' -> vai ao dictionary e escolhe ao random uma das perguntas.
        //Se uma pergunta ja estiver a ser usada guarda-se essa pergunta num novo dictionary
        //e remove-se do original para nao haver repeticoes, depois caso o dictionary
        //original estiver vazio usa-se o secundario

        if (nuncaUncas.Count == 0 && using1)
        {
            using1 = false;
            using2 = true;
        }
        else if (_nuncaUncas_.Count == 0 && using2)
        {
            using2 = false;
            using1 = true;
        }


        if (using1)
        {
            randomNumber = Random.Range(0, nuncaUncas.Count);
            nuncaUncaText.text = "..." + nuncaUncas[randomNumber].ToLower();
            _nuncaUncas_.Add(nuncaUncas[randomNumber]);
            nuncaUncas.Remove(nuncaUncas[randomNumber]);
        }
        if (using2)
        {
            randomNumber = Random.Range(0, _nuncaUncas_.Count);
            nuncaUncaText.text = "..." + _nuncaUncas_[randomNumber].ToLower();
            nuncaUncas.Add(_nuncaUncas_[randomNumber]);
            _nuncaUncas_.Remove(_nuncaUncas_[randomNumber]);
        }
    }

    public void GenerateMLT()
    {
        //string[] allLines = File.ReadAllLines(Application.persistentDataPath + MLTCSVPath);
        string[] allLines = MLTcvs.text.Split("\n"[0]); ;
        foreach (string uncas in allLines)
        {
            if (uncas != "")
            {
                nuncaUncas.Add(uncas);
            }
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
