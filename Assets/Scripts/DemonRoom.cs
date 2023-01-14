using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRoom : MonoBehaviour
{
    [SerializeField] private GameObject puzzleWindow;
    [SerializeField] private DemonSO currentDemonSO;
    [SerializeField] private SpriteRenderer demonSpriteRenderer;

    private void Start()
    {
        demonSpriteRenderer.sprite = currentDemonSO.demonSprite;
    }

    public void OnStartPuzzleButtonClicked()
    {
        puzzleWindow.gameObject.SetActive(true);
    }

    public void ClickComeBack(GameObject prefabCityMap)
    {
        Instantiate(prefabCityMap, prefabCityMap.transform.position, prefabCityMap.transform.rotation);
        Destroy(this.gameObject);
    }
}
