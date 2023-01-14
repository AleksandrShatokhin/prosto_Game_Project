using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Demon", menuName = "ScriptableObjects/DemonSO", order = 1)]
public class DemonSO : ScriptableObject
{
    public Sprite demonSprite;

    //Список предметов, которые необходимо выбрать игроку для получения подсказки/упрощения головоломки
    public List<Items> neededItems;
}
