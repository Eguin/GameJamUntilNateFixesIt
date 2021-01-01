using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SetTMPInfected : MonoBehaviour
{
    Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Infected: " + ScoreHandler.infected.ToString() + "\n" +
            "Infected Limit: " + ScoreHandler.getMaxInfected() + "\n" +
            "Percentage: " + (((float)ScoreHandler.infected) / ((float)ScoreHandler.getMaxInfected()) * 100).ToString() + "%";
    }
}
