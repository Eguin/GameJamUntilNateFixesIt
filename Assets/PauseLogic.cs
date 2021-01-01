using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseLogic : MonoBehaviour
{
    [SerializeField]
    UnityEvent onPause;

    [SerializeField]
    UnityEvent offPause;

    bool isPaused=false;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseFunc();
        }
    }

    public void pauseFunc()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            offPause.Invoke();
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            onPause.Invoke();
            isPaused = true;
        }
    }
}
