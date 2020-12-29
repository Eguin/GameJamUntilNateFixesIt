using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour {
    public static int currentLevel;
    public static int amountOfLevels = 100;

    [SerializeField]
    int levelNumber;

    private void Start()
    {
        currentLevel = levelNumber;
    }

    public void unlockLevel()
    {
        SaveFileHandler.SaveGame(levelNumber);
    }
}
