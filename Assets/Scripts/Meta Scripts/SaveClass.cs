using System;
using UnityEngine;

[Serializable]
public class SaveClass {
    public int[] highScores=new int[LevelHandler.amountOfLevels];
    public int levelUnlocked;

    public SaveClass()
    {
        for(int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = 9999;
        }
        levelUnlocked = 0;
    }

}
