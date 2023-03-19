using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LabyrinthCircle : MonoBehaviour
{
    [SerializeField] private LabyrinthPuzzle puzzle;
    [SerializeField] private float speed = 1;
    private LabyrinthCheckpoint currentCheckpoint;
    [SerializeField] private List<LabyrinthCheckpoint> checkpoints;
    private bool isMouseButtonPressed = false;

    private void Awake()
    {
        currentCheckpoint = checkpoints[0];
        RestartFromCheckpoint();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isMouseButtonPressed = true;
        }
        else
        {
            isMouseButtonPressed = false;
        }
    }

    void FixedUpdate()
    {
        if (isMouseButtonPressed)
        {
            var positon = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(transform.position, positon) > 0.15f)
            {
                GetComponent<Rigidbody2D>().AddForce((positon - transform.position) * speed);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        LabyrinthCheckpoint passedCheckpoint = other.GetComponent<LabyrinthCheckpoint>();
        if (passedCheckpoint != null)
        {
            if (GetCheckpointIndex(currentCheckpoint) == GetCheckpointIndex(passedCheckpoint) - 1)
            {
                currentCheckpoint = passedCheckpoint;
                passedCheckpoint.ActivateCheckpoint();

                if (GetCheckpointIndex(currentCheckpoint) == checkpoints.Count - 1)
                {
                    Debug.Log("Прошел");
                    puzzle.OnPuzzleEnd();
                }
            }
        }
    }

    private int GetCheckpointIndex(LabyrinthCheckpoint checkpoint)
    {
        for (var i = 0; i < checkpoints.Count; i++)
        {
            if (checkpoints[i] == checkpoint)
            {
                return i;
            }
        }
        return -1;
    }

    public void RestartFromCheckpoint(bool restartFromStart = false)
    {
        if (restartFromStart == true)
        {
            transform.position = checkpoints[0].transform.position;
            currentCheckpoint = checkpoints[0];
            // Сбросить прогресс
        }
        else
        {
            transform.position = currentCheckpoint.transform.position;
        }
    }
}
