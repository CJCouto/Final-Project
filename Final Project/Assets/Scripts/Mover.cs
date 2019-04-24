using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    private GameController gameController;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (gameController.mode == 1)
        {
            rb.velocity = transform.forward * speed * 2;
        }
        else {
            rb.velocity = transform.forward * speed;
        }
    }
}