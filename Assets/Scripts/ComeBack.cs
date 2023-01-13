using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeBack : MonoBehaviour
{
    

    public void StepBack(GameObject prefabPlayerRoom)
    {
        GameObject cityMap = GameObject.FindGameObjectWithTag("DeliteObject");

        Instantiate(prefabPlayerRoom, prefabPlayerRoom.transform.position, prefabPlayerRoom.transform.rotation);
        Destroy(cityMap);

       
    }

}
