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
    /// Sound when brick hit
    /// </summary>
    public AudioClip Crack;

    /// <summary>
    /// Number of remaining bricks
    /// (Static are not shown in editor)
    /// </summary>
    public static int BreakableCount = 0;

    /// <summary>
    /// Times the brick has been hit
    /// </summary>
    private int timesHit;

    /// <summary>
    /// Reference to level manager
    /// </summary>
    private LevelManager levelManager;

    /// <summary>
    /// True if brick is breakable
    /// </summary>
    private bool isBreakable;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = this.tag == "Breakable";
        if (isBreakable)
            BreakableCount = BreakableCount + 1;
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Collision effect if brick is breakable
        if (isBreakable)
        {
            AudioSource.PlayClipAtPoint(Crack, this.transform.position);
            HandleHit();
        }
    }

    void HandleHit()
    {
        int maxHits = HitSprites.Length + 1;
        timesHit = timesHit + 1;
        // Destruction
        if (timesHit >= maxHits)
        {
            BreakableCount = BreakableCount - 1;
            levelManager.BrickDestroyedMessage();
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
