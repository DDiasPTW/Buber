using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Handler : MonoBehaviour
{
    public GameObject games_Menu, drinks_Menu;

    private void Awake()
    {
        games_Menu.SetActive(false);
        drinks_Menu.SetActive(false);
    }

    public void OpenDrinks()
    {
        drinks_Menu.SetActive(true);
    }

    public void CloseDrinks()
    {
        drinks_Menu.SetActive(false);
    }

    public void OpenGames()
    {
        games_Menu.SetActive(true);
    }

    public void CloseGames()
    {
        games_Menu.SetActive(false);
    }

    public void NuncaUnca()
    {
        SceneManager.LoadScene("Never_have_i_ever");
    }
}
