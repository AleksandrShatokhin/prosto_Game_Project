using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Demon", menuName = "ScriptableObjects/DemonSO", order = 1)]
public class DemonSO : ScriptableObject
{
    public Sprite demonSprite;

    // Список предметов, которые необходимо выбрать игроку для получения подсказки/упрощения головоломки
    public List<Items> neededItems;

    // Список возможных сообщений к конкретному демону от горожан
    public List<string> message;

    // Варианты спрайтов горожан
    public List<Sprite> citizenSprite;

    //Префаб головоломки для данного демона
    public GameObject puzzlePrefab;
}
