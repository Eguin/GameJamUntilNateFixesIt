using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour {
    public static int currentLevel;
    public static int amountOfLevels = 100;

    public void setLevel(int level)
    {
        currentLevel = level;
    }
}
