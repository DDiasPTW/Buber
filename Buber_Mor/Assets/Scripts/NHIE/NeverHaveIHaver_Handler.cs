using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverHaveIHaver_Handler : MonoBehaviour
{
    public Dictionary<string, int> NuncaUnca = new Dictionary<string, int>();
    public Dictionary<string, int> _NuncaUnca_= new Dictionary<string, int>();


   
    public void NextUnca() 
    {
        //Serve para o botao 'next' -> vai ao dictionary e escolhe ao random uma das perguntas.
        //Se uma pergunta ja estiver a ser usada guarda-se essa pergunta num novo dictionary
        //e remove-se do original para nao haver repeticoes, depois caso o dictionary
        //original estiver vazio usa-se o secundario
    }
}
