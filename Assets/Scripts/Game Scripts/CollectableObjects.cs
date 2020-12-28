using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
    GameObject player;

    float distanceFromObject;

    Collectables collectableScript;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position)<distanceFromObject)
        {
            collected();
        }
    }

    public void setPlayer(GameObject p)
    {
        player = p;
    }
    
    public void setDistance(float d)
    {
        distanceFromObject = d;
    }

    public void setCollectablesScript(Collectables col)
    {
        collectableScript = col;
    }

    void collected()
    {
        collectableScript.removeItem(this);
        Destroy(gameObject);
    }
}
