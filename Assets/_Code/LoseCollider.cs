﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    public LevelManager LevelManager;

    void OnTriggerEnter2D(Collider2D collider)
    {
        LevelManager.LoadLevel("Loss");
    }
}
