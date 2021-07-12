using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkRecipesMenu_Handler : MonoBehaviour
{
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
    }
}
