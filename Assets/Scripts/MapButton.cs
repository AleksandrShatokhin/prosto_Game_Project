using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButton : MonoBehaviour
{

    [SerializeField] private GameObject CityMap;
    
   
    public void MapClick()
    {
        Instantiate(CityMap, new Vector3(0, 0, 0), Quaternion.identity);
        
    }
}
