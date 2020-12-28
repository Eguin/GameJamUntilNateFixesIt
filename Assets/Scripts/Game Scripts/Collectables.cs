using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectables : MonoBehaviour
{
    [SerializeField]
    List<CollectableObjects> objectsToCollect;

    [SerializeField]
    GameObject player;

    [SerializeField]
    float distanceFromPlayer;

    [SerializeField]
    Text itemsList;

    // Start is called before the first frame update
    void Start()
    {
        itemsList.text = "";
        for(int i = 0; i < objectsToCollect.Count ; i++)
        {
            itemsList.text += objectsToCollect[i].gameObject.ToString() + "\n";
            objectsToCollect[i].setPlayer(player);
            objectsToCollect[i].setDistance(distanceFromPlayer);
            objectsToCollect[i].setCollectablesScript(this);
        }
    }

    public void removeItem(CollectableObjects collectedObject)
    {
        objectsToCollect.Remove(collectedObject);
        for (int i = 0; i < objectsToCollect.Count; i++)
        {
            itemsList.text += objectsToCollect[i].gameObject.ToString() + "\n";
        }
        if (objectsToCollect.Count == 0)
        {
            //end level
        }
    }
}
