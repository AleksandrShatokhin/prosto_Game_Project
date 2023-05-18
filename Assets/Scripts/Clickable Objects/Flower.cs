using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour, IClickable
{
    private Animator anim_Flower;

    private void Start()
    {
        anim_Flower = GetComponent<Animator>();
    }
    
    public void OnClick()
    {
        anim_Flower.SetTrigger("isFall");
    }
}
