using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour {
    public static int infected;

    /*
     * Only put this script on an object in the scene if you want the score to reset at the start of the scene
     * otherwise don't put in on a specific gameobject
     */

	// Use this for initialization
	void Start () {
        infected = 0;
	}
}
