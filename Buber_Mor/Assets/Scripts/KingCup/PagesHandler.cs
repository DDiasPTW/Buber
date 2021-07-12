using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PagesHandler : MonoBehaviour
{
    public GameObject previousPage, currentPage, nextPage;

    public void Previous()
    {
        previousPage.SetActive(true);
        currentPage.SetActive(false);
    }

    public void Next()
    {
        nextPage.SetActive(true);
        currentPage.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
