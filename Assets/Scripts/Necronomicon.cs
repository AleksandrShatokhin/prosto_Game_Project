using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Necronomicon : MonoBehaviour
{
    [SerializeField] private Image imagePage;
    [SerializeField] private TextMeshProUGUI textPage;

    [SerializeField] private Button buttonNextPage, buttonPreviousPage;

    [SerializeField] private List<NecronomiconSO> pages;
    [SerializeField] private int indexPage = 0;

    private void Start()
    {
        buttonNextPage.onClick.AddListener(ClickNextPage);
        buttonPreviousPage.onClick.AddListener(ClickPreviousPage);
    }

    private void OnEnable()
    {
        indexPage = 0;
        UpdatePageContent();
    }

    private void UpdatePageContent()
    {
        imagePage.sprite = pages[indexPage].spritePage;
        textPage.text = pages[indexPage].textPage.ToString();

        ChackActivityButtonsTransitionPage();
    }

    private void ChackActivityButtonsTransitionPage()
    {
        if (indexPage == pages.Count - 1)
        {
            buttonNextPage.gameObject.SetActive(false);
        }
        else
        {
            buttonNextPage.gameObject.SetActive(true);
        }

        if (indexPage == 0)
        {
            buttonPreviousPage.gameObject.SetActive(false);
        }
        else
        {
            buttonPreviousPage.gameObject.SetActive(true);
        }
    }

    private void ClickNextPage()
    {
        indexPage += 1;
        UpdatePageContent();
    }

    private void ClickPreviousPage()
    {
        indexPage -= 1;
        UpdatePageContent();
    }
}