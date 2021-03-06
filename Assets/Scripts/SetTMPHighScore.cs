﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SetTMPHighScore : MonoBehaviour
{
    Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
        t.text = "Level: "+(LevelHandler.currentLevel+1).ToString()+"\n" +
            "High Score: " + SaveFileHandler.currentSaveData.highScores[LevelHandler.currentLevel].ToString();
    }

}
