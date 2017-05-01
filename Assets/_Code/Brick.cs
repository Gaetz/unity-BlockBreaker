using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int MaxHits;
    int timesHit;
    LevelManager levelManager;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if(timesHit >= MaxHits)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit = timesHit + 1;
        //Win();
    }

    void Win()
    {
        LevelManager.LoadNextLevel();
    }
}
