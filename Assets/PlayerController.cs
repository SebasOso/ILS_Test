using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb; // referencia al Rigidbody del jugador

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        //Movement
        float moveHorizontal = Input.GetAxis("Horizontal"); // obtenemos la entrada horizontal (A/D o flechas)
        float moveVertical = Input.GetAxis("Vertical"); // obtenemos la entrada vertical (W/S o flechas)
        transform.Translate(moveHorizontal, 0, moveVertical);
        //Rotation
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

    }
}
