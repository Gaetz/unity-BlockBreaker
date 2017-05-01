using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    /// <summary>
    /// True if computer play alone
    /// </summary>
    public bool Autoplay;

    const float ScreenWidthInGameUnit = 16f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Autoplay)
            AutoUpdate();
        else
            PlayerUpdate();
	}

    private void PlayerUpdate()
    {
        float xPosition = Mathf.Clamp(Input.mousePosition.x / Screen.width * ScreenWidthInGameUnit, 0.5f, 15.5f);
        transform.position = new Vector3(xPosition, this.transform.position.y, this.transform.position.z);
    }

    private void AutoUpdate()
    {
        float xPosition = GameObject.FindObjectOfType<Ball>().GetComponent<Transform>().position.x;
        transform.position = new Vector3(xPosition, this.transform.position.y, this.transform.position.z);
    }
}
