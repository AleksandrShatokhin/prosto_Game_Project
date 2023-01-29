using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CirclePuzzle : MonoBehaviour
{
    [Header("!!!Case sensitive!!!")]
    [SerializeField] private string answerWord = "DEMON";
    [SerializeField] private List<char> circleLetters;
    [SerializeField] private GameObject circleLetterPrefab;
    [SerializeField] private float circleRadius;
    [SerializeField] private Vector2 circlePosition;

    [SerializeField] private Transform chosenLettersPosition;
    [SerializeField] private float chosenLettersDistance;
    [SerializeField] private GameObject chosenLetterPrefab;

    [SerializeField] private MouseHandler mouseHandler;
    private List<GameObject> chosenLetters = new List<GameObject>();
    [SerializeField] GameObject infoWindow;
    [SerializeField] GameObject hintTextObject;
    public DemonRoom demonRoom;
    public GameObject puzzleWindow;

    private string playerAnswer = null;
    private int currentLetterNumber = 0;
    private int openedLetter = 100;

    //Testing
    private List<GameObject> createdCircleLetters = new List<GameObject>();

    private void Awake()
    {
        CreateCirleOfLetters();
        CreateChosenLettersSlots();
    }

    private void CreateCirleOfLetters()
    {
        float circleLetterStepDegrees = 360 / circleLetters.Count;
        float currentAngle = 0;
        foreach (char letter in circleLetters)
        {
            Vector2 letterPosition = CalculateCircleLetterPosition(currentAngle);
            GameObject createdLetter = GameObject.Instantiate(circleLetterPrefab, letterPosition, Quaternion.identity, this.transform);

            //Testing
            createdCircleLetters.Add(createdLetter);
            //Delete later

            currentAngle += circleLetterStepDegrees;
            createdLetter.GetComponent<CircleLetter>().InstantiateCircleLetter(letter, this);
        }
    }

    private void CreateChosenLettersSlots()
    {
        for (var i = 0; i < answerWord.Length; i++)
        {
            GameObject createdSlot = Instantiate(chosenLetterPrefab, new Vector3(chosenLettersDistance * i + chosenLettersPosition.position.x, chosenLettersPosition.position.y),
                Quaternion.identity, this.transform);
            chosenLetters.Add(createdSlot);
        }
    }

    private Vector2 CalculateCircleLetterPosition(float currentAngle)
    {
        float x = transform.position.x + circleRadius * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = transform.position.y + circleRadius * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
        return new Vector2(x + circlePosition.x, y + circlePosition.y);
    }

    private void CheckAnswer()
    {
        if (playerAnswer == answerWord)
        {
            ClearPuzzleScreen();
            GameObject createdWindow = Instantiate(infoWindow, transform.position, Quaternion.identity, this.transform);
            createdWindow.GetComponent<InformationWindow>().SetWindowText("Демон: 'О нет я изгнан'");
            StartCoroutine(WindowCloseTimer());
        }
        else
        {
            ResetPuzzle();
        }
    }

    private void ResetPuzzle()
    {
        playerAnswer = null;
        mouseHandler.ResetLine();
        currentLetterNumber = 0;

        foreach (var item in createdCircleLetters)
        {
            item.GetComponent<TMP_Text>().color = Color.white;
        }

        for (var i = 0; i < chosenLetters.Count; i++)
        {
            if (i != openedLetter)
            {
                chosenLetters[i].GetComponentInChildren<TMP_Text>().text = null;
            }
            else
            {
                chosenLetters[i].GetComponentInChildren<TMP_Text>().text = answerWord[openedLetter].ToString();
            }
        }
    }


    private IEnumerator WindowCloseTimer()
    {
        yield return new WaitForSeconds(2f);
        puzzleWindow.SetActive(false);
        demonRoom.ClickComeBack();
    }


    private void ClearPuzzleScreen()
    {
        foreach (var item in createdCircleLetters)
        {
            Destroy(item);
        }

        foreach (var item in chosenLetters)
        {
            Destroy(item);
        }

        mouseHandler.ResetLine();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(circlePosition, circleRadius);
    }

    public void AddLetterToAnswer(char letterToAdd)
    {
        playerAnswer = playerAnswer + letterToAdd;
        chosenLetters[currentLetterNumber].GetComponentInChildren<TMP_Text>().text = letterToAdd.ToString();
        currentLetterNumber++;
        if (playerAnswer.Length == answerWord.Length)
        {
            CheckAnswer();
        }
    }

    public void OpenRandomLetter()
    {
        int randomLetterIndex = Random.Range(0, answerWord.Length);
        openedLetter = randomLetterIndex;
        chosenLetters[randomLetterIndex].GetComponentInChildren<TMP_Text>().text = answerWord[randomLetterIndex].ToString();
    }

    public void OpenTextHint()
    {
        hintTextObject.SetActive(true);
    }

    //Временный рофлан. Сделать базовый абстрактный класс головоломки, с переопределенными методами HandleHints и т.д., чтобы можно было обращаться к любой головоломке через parent класс.
    public void HandleHints(int numberOfHints)
    {
        if (numberOfHints > 0)
        {
            OpenRandomLetter();
        }
        if (numberOfHints == 2)
        {
            OpenTextHint();
        }
    }
}
