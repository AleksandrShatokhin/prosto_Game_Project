using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeBack : MonoBehaviour
{
    

    public void StepBack()
    {
        GameObject cityMap = GameObject.FindGameObjectWithTag("DeliteObject");

        Destroy(cityMap);

       
    }

}
