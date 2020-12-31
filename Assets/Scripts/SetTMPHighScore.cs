using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SetTMPHighScore : MonoBehaviour
{
    TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = "Level: "+(LevelHandler.currentLevel+1).ToString()+" High Score: " + SaveFileHandler.currentSaveData.highScores[LevelHandler.currentLevel].ToString();
    }

}
