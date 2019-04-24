using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMover : MonoBehaviour {

    private GameController gameController;
    private ParticleSystem particleSystem;
    private float horizSliderValue = 1.0f;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        particleSystem = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        var main = particleSystem.main;

        main.simulationSpeed = horizSliderValue;

        if (gameController.win == true) {
            if (horizSliderValue <= 60) {
                horizSliderValue += .03f;
            }
        }
        //if (gameController.win == false && horizSliderValue <= 30)
        //{
        //    horizSliderValue += 0.005f;
        //}
    }
}
