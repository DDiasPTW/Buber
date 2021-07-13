using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NeverHaveIHaver_Handler : MonoBehaviour
{
    public List<string> nuncaUncas = new List<string>();
    public List<string> _nuncaUncas_ = new List<string>();

    public bool using1 = true, using2 = false;

    public Text nuncaUncaText;

    private int randomNumber;
    private void Awake()
    {
        NextUnca();
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
            nuncaUncaText.text = nuncaUncas[randomNumber];
            _nuncaUncas_.Add(nuncaUncas[randomNumber]);
            nuncaUncas.Remove(nuncaUncas[randomNumber]);
        }
        else if(using2)
        {
            randomNumber = Random.Range(0, _nuncaUncas_.Count);
            nuncaUncaText.text = _nuncaUncas_[randomNumber];
            nuncaUncas.Add(_nuncaUncas_[randomNumber]);
            _nuncaUncas_.Remove(_nuncaUncas_[randomNumber]);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
