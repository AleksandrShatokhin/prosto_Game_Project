using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDataBase : MonoBehaviour
{
    [SerializeField] List<DemonSO> demonSO;
    public DemonSO GetDemon(int number) => demonSO[number];
    public int GetCountFromListDemons() => demonSO.Count;
}
