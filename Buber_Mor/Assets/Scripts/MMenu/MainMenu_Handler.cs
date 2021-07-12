using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Handler : MonoBehaviour
{
    public void NuncaUnca()
    {
        SceneManager.LoadScene("Never_have_i_ever");
    }

    public void KingsCup()
    {
        SceneManager.LoadScene("Kings_Cup");
    }
}
