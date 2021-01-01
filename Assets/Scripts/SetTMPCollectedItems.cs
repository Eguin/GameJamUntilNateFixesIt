using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SetTMPCollectedItems : MonoBehaviour
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
        t.text = "Objects Collected: " + ScoreHandler.amountCollected.ToString();
    }
}
