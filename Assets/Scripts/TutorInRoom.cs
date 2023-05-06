using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorInRoom : MonoBehaviour
{
    [SerializeField] private Image imageObject;

    public void OnEnable()
    {
        GameController.GetInstance().GetTutorialBookComponent().AddNewPage(imageObject.sprite);
    }
}
