using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public GameObject thisRecipeUI;

    public void OpenMenu()
    {
        thisRecipeUI.SetActive(true);
    }
}
