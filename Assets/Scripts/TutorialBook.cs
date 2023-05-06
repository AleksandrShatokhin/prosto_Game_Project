using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBook : MonoBehaviour
{
    [SerializeField] private Image imagePage;

    [SerializeField] private Button buttonNextPage, buttonPreviousPage;

    [SerializeField] private List<Sprite> pages;
    [SerializeField] private int indexPage = 0;

    private void Start()
    {
        buttonNextPage.onClick.AddListener(ClickNextPage);
        buttonPreviousPage.onClick.AddListener(ClickPreviousPage);
    }

    private void OnEnable()
    {
        indexPage = 0;

        if (pages.Count == 0)
        {
            buttonNextPage.gameObject.SetActive(false);
            buttonPreviousPage.gameObject.SetActive(false);
            return;
        }

        UpdatePageContent();
    }

    private void UpdatePageContent()
    {
        imagePage.sprite = pages[indexPage];

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

    public void AddNewPage(Sprite page)
    {
        foreach (Sprite currentPage in pages)
        {
            if (currentPage == page)
            {
                return;
            }
        }

        pages.Add(page);
    }

    public void ClosePanel() => GameController.GetInstance().ClosePanel(this.gameObject);
}
