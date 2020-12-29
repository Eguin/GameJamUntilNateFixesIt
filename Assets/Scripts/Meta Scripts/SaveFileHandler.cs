using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class SaveFileHandler : MonoBehaviour
{
    public static SaveClass currentSaveData=new SaveClass();

    [MenuItem("Save File Handler/Reset Data")]
    public static void ResetData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+ "/Save.data");
        SaveClass data = new SaveClass();
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data reset!");
    }

    public static void SaveGame()
    {
        if (File.Exists(Application.persistentDataPath+ "/Save.data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
                         + "/Save.data");
            SaveClass data = new SaveClass();
            data = currentSaveData;
            if (ScoreHandler.infected < currentSaveData.highScores[LevelHandler.currentLevel])
            {
                data.highScores[LevelHandler.currentLevel] = ScoreHandler.infected;
            }
            else
            {
                data.highScores[LevelHandler.currentLevel] = currentSaveData.highScores[LevelHandler.currentLevel];
            }
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Game data saved!");
            LoadGame();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath+ "/Save.data");
            SaveClass data = new SaveClass();
            data.highScores[LevelHandler.currentLevel] = ScoreHandler.infected;
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("New Game data saved!");
            LoadGame();
        }
    }

    public static void SaveGame(int level)
    {
        if (File.Exists(Application.persistentDataPath + "/Save.data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
                         + "/Save.data");
            SaveClass data = new SaveClass();
            data = currentSaveData;
            if (ScoreHandler.infected < currentSaveData.highScores[LevelHandler.currentLevel])
            {
                data.highScores[LevelHandler.currentLevel] = ScoreHandler.infected;
            }
            else
            {
                data.highScores[LevelHandler.currentLevel] = currentSaveData.highScores[LevelHandler.currentLevel];
            }
            if (level > currentSaveData.levelUnlocked)
            {
                data.levelUnlocked = level;
            }
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Game data saved!");
            LoadGame();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/Save.data");
            SaveClass data = new SaveClass();
            data.highScores[LevelHandler.currentLevel] = ScoreHandler.infected;
            data.levelUnlocked = level;
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("New Game data saved!");
            LoadGame();
        }
    }

    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath+ "/Save.data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =File.Open(Application.persistentDataPath+ "/Save.data", FileMode.Open);
            SaveClass data = (SaveClass)bf.Deserialize(file);
            file.Close();
            currentSaveData = data;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    /*public static void unlockLevel(int level)
    {
        if (File.Exists(Application.persistentDataPath+ "/Save.data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath+ "/Save.data");
            SaveClass data = new SaveClass();
            data=currentSaveData;
            if (level > currentSaveData.levelUnlocked)
            {
                data.levelUnlocked = level;
            }
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("Unlocked Level "+level.ToString());
            LoadGame();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath+ "/Save.data");
            SaveClass data = new SaveClass();
            data.levelUnlocked = level;
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("New Game data saved! With Level Unlocked: " +level.ToString());
            LoadGame();
        }
    }*/

    public void saveGameInstance()
    {
        SaveGame();
    }

    private void Awake()
    {
        LoadGame();
    }

}