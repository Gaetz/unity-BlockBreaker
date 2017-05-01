using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    /// <summary>
    /// Reference to paddle
    /// </summary>
    Paddle paddle;

    /// <summary>
    /// Distance to paddle
    /// </summary>
    Vector3 paddleToBall;

    /// <summary>
    /// True when the ball is launched
    /// </summary>
    bool isBallLaunched;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBall = this.transform.position - paddle.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if(!isBallLaunched)
        {
            // Ball on paddle
            this.transform.position = paddle.transform.position + paddleToBall;
            // Ball lauched on click
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 10f);
                isBallLaunched = true;
            }
        }
    }
}
