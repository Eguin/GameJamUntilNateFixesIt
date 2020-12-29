using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGreen : MonoBehaviour
{
    [SerializeField]
    MeshRenderer mr;

    public void makeGreen()
    {
        mr.material.color = Color.red;
    }
}
