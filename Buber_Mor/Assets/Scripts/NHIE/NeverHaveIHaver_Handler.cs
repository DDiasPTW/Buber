using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NeverHaveIHaver_Handler : MonoBehaviour
{
    //Listas que vao segurar os NHIE
    [SerializeField]
    private List<string> nuncaUncas = new List<string>();
    [SerializeField]
    private List<string> _nuncaUncas_ = new List<string>();

    //Local onde esta o ficheiro que contem os NHIE
    //private static string NHIECSVPath = "/Scripts/NHIE/NHIE_Questions.csv";
    [SerializeField] private TextAsset NHIEcvs;
    //Que lista esta a ser usada
    public bool using1 = true, using2 = false;

    //O texto dos NHIE
    public Text nuncaUncaText;

    //Texto que aparece antes do jogo ser iniciado
    [Multiline]
    public string begginingText;

    //Que NHIE e escolhido
    private int randomNumber;
    private void Awake()
    {
        NHIEcvs = Resources.Load<TextAsset>("NHIE_Questions");
        using1 = true;
        using2 = false;
        GenerateNHIE();
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
        if(using2)
        {
            randomNumber = Random.Range(0, _nuncaUncas_.Count);
            nuncaUncaText.text = "..." + _nuncaUncas_[randomNumber].ToLower();
            nuncaUncas.Add(_nuncaUncas_[randomNumber]);
            _nuncaUncas_.Remove(_nuncaUncas_[randomNumber]);
        }
    }

    public void GenerateNHIE()
    {
        //string[] allLines = File.ReadAllLines(Application.persistentDataPath + NHIECSVPath);
        string[] allLines = NHIEcvs.text.Split("\n"[0]); ;
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
