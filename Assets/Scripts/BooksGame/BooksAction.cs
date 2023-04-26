using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksAction : MonoBehaviour, IClickable
{
    [SerializeField] private BooksManager bookManager;
    [SerializeField] private GameObject frame;
    public Vector2 DefaultLocalPosition { get; private set; }

    void Start()
    {
        DefaultLocalPosition = this.gameObject.transform.localPosition;
    }

    public void OnClick()
    {
        bookManager.SetBook(this.gameObject);
    }

    public void Frame_On() => frame.SetActive(true);
    public void Frame_Off() => frame.SetActive(false);

    public void SetNewPosition(Vector2 position)
    {
        DefaultLocalPosition = position;
        this.transform.localPosition = DefaultLocalPosition;
    }
}
