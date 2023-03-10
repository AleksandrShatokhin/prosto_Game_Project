using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Demon", menuName = "ScriptableObjects/DemonSO", order = 1)]
public class DemonSO : ScriptableObject
{
    // Внешний вид демона
    public Sprite demonSprite;

    // Список предметов, которые необходимо выбрать игроку для получения подсказки/упрощения головоломки
    public List<Items> neededItems;

    // Список возможных сообщений к конкретному демону от горожан
    public TextAsset message;

    // Варианты спрайтов горожан
    public Sprite citizenSprite;

    //Префаб комнаты для данного демона
    public GameObject demonRoomPrefab;
}
