using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        Brick.BreakableCount = 0;
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    internal static void LoadNextLevel()
    {
        Brick.BreakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyedMessage()
    {
        if (Brick.BreakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
