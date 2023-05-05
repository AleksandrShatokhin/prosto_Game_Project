using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitToSoupeRecipe : MonoBehaviour, IClickable
{
    [SerializeField] private GameObject soupRecipeWindow;

    public void OnClick()
    {
        soupRecipeWindow.SetActive(true);
    }
}
