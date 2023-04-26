using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> selectedBooks;

    public void SetBook(GameObject book)
    {
        selectedBooks.Add(book);
        book.GetComponent<BooksAction>().Frame_On();

        if (selectedBooks.Count == 2)
        {
            Vector2 positionBook_1 = selectedBooks[0].GetComponent<BooksAction>().DefaultLocalPosition;
            Vector2 positionBook_2 = selectedBooks[1].GetComponent<BooksAction>().DefaultLocalPosition;

            selectedBooks[0].GetComponent<BooksAction>().SetNewPosition(positionBook_2);
            selectedBooks[1].GetComponent<BooksAction>().SetNewPosition(positionBook_1);

            foreach (GameObject selBook in selectedBooks)
            {
                selBook.GetComponent<BooksAction>().Frame_Off();
            }

            selectedBooks.Clear();
        }
    }
}
