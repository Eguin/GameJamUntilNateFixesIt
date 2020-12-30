using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour {
    public static int infected=0;

    [SerializeField]
    float maxInfected=100;

    [SerializeField]
    UnityEvent onLoose;

    /*
     * Only put this script on an object in the scene if you want the score to reset at the start of the scene
     * otherwise don't put in on a specific gameobject
     */

    // Use this for initialization
    void Start () {
        infected = 0;
	}

    private void Update()
    {
        if (infected >= maxInfected)
        {
            onLoose.Invoke();
        }
    }
}
