using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Handler : MonoBehaviour
{
    public GameObject MainMenu,IBreaker_Menu, CardGames_Menu, Other_Games_Menu;
    private void Awake()
    {
        MainMenu.SetActive(true);
        IBreaker_Menu.SetActive(false);
        CardGames_Menu.SetActive(false);
        Other_Games_Menu.SetActive(false);
    }

    public void IbreakerMenu()
    {
        IBreaker_Menu.SetActive(true);
    }

    public void CardGamesMenu()
    {
        CardGames_Menu.SetActive(true);
    }

    public void OtherGames()
    {
        Other_Games_Menu.SetActive(true);
    }
    public void NuncaUnca()
    {
        SceneManager.LoadScene("Never_have_i_ever");
    }

    public void MostLikely()
    {
        SceneManager.LoadScene("Most_likely_to");
    }

    public void TOD()
    {
        SceneManager.LoadScene("TOD");
    }
    public void DOD()
    {
        SceneManager.LoadScene("DOD");
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

    public void IPoker()
    {
        SceneManager.LoadScene("IndiaPoker");
    }

    public void Neighbour()
    {
        SceneManager.LoadScene("Neighbour");
    }

    public void Irish()
    {
        SceneManager.LoadScene("Irish");
    }

    public void Minesweeper()
    {
        SceneManager.LoadScene("Minesweeper");
    }

    public void StraightFace()
    {
        SceneManager.LoadScene("StraightFace");
    }

    public void Fuzzy()
    {
        SceneManager.LoadScene("Fuzzy");
    }

    public void Bingo()
    {
        SceneManager.LoadScene("Bingo");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
