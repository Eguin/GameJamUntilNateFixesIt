using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOneActive : MonoBehaviour
{
    [SerializeField]
    GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks + SetPersonDestination.randomSeed);
        for(int i = 0; i > objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
        objects[Random.Range(0, objects.Length)].SetActive(true);
    }
}
