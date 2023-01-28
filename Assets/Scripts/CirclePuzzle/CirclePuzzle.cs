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

    [SerializeField] GameObject congratulationsText;

    private string playerAnswer = null;
    private int currentLetterNumber = 0;


    //Testing
    private List<GameObject> letterCircleToDestroy = new List<GameObject>();

    private void Start()
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
            letterCircleToDestroy.Add(createdLetter);
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
        return new Vector2(x, y);
    }

    private void CheckAnswer()
    {
        if (playerAnswer == answerWord)
        {
            ClearPuzzleScreen();
            congratulationsText.SetActive(true);
            //Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Checking for answer, reseting stuff");
            Debug.Log("Wrong answer");
            playerAnswer = null;
            mouseHandler.ResetLine();
            currentLetterNumber = 0;
            foreach (GameObject letterSlot in chosenLetters)
            {
                letterSlot.GetComponentInChildren<TMP_Text>().text = null;
            }
        }
    }

    private void ClearPuzzleScreen()
    {
        foreach (var item in letterCircleToDestroy)
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
}
