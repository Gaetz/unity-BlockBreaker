using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    /// <summary>
    /// Break stages Sprites
    /// </summary>
    public Sprite[] HitSprites;

    /// <summary>
    /// Times the brick has been hit
    /// </summary>
    private int timesHit;

    /// <summary>
    /// Reference to level manager
    /// </summary>
    LevelManager levelManager;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision effect if brick is breakable
        if (this.tag == "Breakable")
            HandleHit();
        // Win condition
        //Win();
    }

    void HandleHit()
    {
        int maxHits = HitSprites.Length + 1;
        timesHit = timesHit + 1;
        // Destruction
        if (timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
        // If not destroyed alter sprite
        else
        {
            ChangeSprite();
        }
    }

    /// <summary>
    /// Change sprite when hit
    /// </summary>
    private void ChangeSprite()
    {
        if(HitSprites[timesHit - 1])
            GetComponent<SpriteRenderer>().sprite = HitSprites[timesHit - 1];
    }

    void Win()
    {
        LevelManager.LoadNextLevel();
    }
}
