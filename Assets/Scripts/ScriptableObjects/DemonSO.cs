using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Demon", menuName = "ScriptableObjects/DemonSO", order = 1)]
public class DemonSO : ScriptableObject
{
    // Внешний вид демона
    public Sprite demonSprite;

    // Список возможных сообщений к конкретному демону от горожан
    public GameObject messageWindowPrefab;

    //Префаб комнаты для данного демона
    public GameObject demonRoomPrefab;
}
