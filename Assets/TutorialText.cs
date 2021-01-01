using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TutorialText : MonoBehaviour
{
    [SerializeField]
    string[] texts;

    [SerializeField]
    GameObject objectToDisableAfter;

    int index = 0;

    Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Text>();
        t.text = texts[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            index++;
            if (index == texts.Length)
            {
                objectToDisableAfter.SetActive(false);
            }
            else
            {
                t.text = texts[index];
            }
        }
    }
}
