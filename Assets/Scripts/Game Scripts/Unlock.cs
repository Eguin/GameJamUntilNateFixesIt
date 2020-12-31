using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    [SerializeField]
    int levelNeeded;
    // Start is called before the first frame update
    void Start()
    {
        if (levelNeeded <= SaveFileHandler.currentSaveData.levelUnlocked)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
