using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Handler : MonoBehaviour
{
    public GameObject MainMenu,IBreaker_Menu, CardGames_Menu;
    private void Awake()
    {
        MainMenu.SetActive(true);
        IBreaker_Menu.SetActive(false);
        CardGames_Menu.SetActive(false);
    }

    public void IbreakerMenu()
    {
        IBreaker_Menu.SetActive(true);
    }

    public void CardGamesMenu()
    {
        CardGames_Menu.SetActive(true);
    }
    public void NuncaUnca()
    {
        SceneManager.LoadScene("Never_have_i_ever");
    }

    public void KingsCup()
    {
        SceneManager.LoadScene("Kings_Cup");
    }

    public void Beeramid()
    {
        SceneManager.LoadScene("Beeramid");
    }

    public void Kings()
    {
        SceneManager.LoadScene("Kings");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
