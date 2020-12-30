using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{

    [SerializeField]
    GameObject[] objectsToChange;

    [SerializeField]
    Color colorToChangeTo;

    public void setColorTo()
    {
        for (int i = 0; i < objectsToChange.Length; i++)
        {
            MeshRenderer mr = objectsToChange[i].GetComponent<MeshRenderer>();
            /*for (int j = 0; j < mr.materials.Length; i++)
            {
                mr.materials[j].color = colorToChangeTo;
            }*/
            mr.material.color = colorToChangeTo;
        }
    }
}
