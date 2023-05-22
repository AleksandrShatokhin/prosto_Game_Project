using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circleprikol : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.RotateAround(this.transform.position, new Vector3(0, 0, 1), Time.deltaTime * rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.RotateAround(this.transform.position, new Vector3(0, 0, 1), -Time.deltaTime * rotationSpeed);
        }
    }
}
