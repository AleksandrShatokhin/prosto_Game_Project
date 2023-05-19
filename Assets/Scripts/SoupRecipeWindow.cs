using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupRecipeWindow : MonoBehaviour
{
    [SerializeField] private GameObject ingredientsRecipe;

    public void AddMark(int numberIngredients) => ingredientsRecipe.transform.GetChild(numberIngredients).gameObject.SetActive(true);

    public void CloseWindow()
    {
        GameController.GetInstance().ClosePanel(this.gameObject);
        UIAudioManager.instance.PlayPaperAudio(0.7f);
    }
}
