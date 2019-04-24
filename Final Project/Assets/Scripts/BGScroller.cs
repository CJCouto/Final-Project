using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    public float tileSizeZ;

    private GameController gameController;
    private Vector3 startPosition;
	
	void Start () {
        startPosition = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (gameController.win == true)
        {
            if (scrollSpeed >= -30)
            {
                scrollSpeed -= 0.03f;
            }
        }
        //if (gameController.win == false && scrollSpeed >= -15) {
        //    scrollSpeed -= 0.005f;
        //}
	}
}
