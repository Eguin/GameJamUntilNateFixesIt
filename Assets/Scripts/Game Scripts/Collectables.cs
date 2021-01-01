using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
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

    [SerializeField]
    UnityEvent onWin;

    [SerializeField]
    UnityEvent onRemove;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        itemsList.text = "Objects to Collect:\n";
        for(int i = 0; i < objectsToCollect.Count ; i++)
        {
            itemsList.text += objectsToCollect[i].gameObject.name + "\n";
            objectsToCollect[i].setPlayer(player);
            objectsToCollect[i].setDistance(distanceFromPlayer);
            objectsToCollect[i].setCollectablesScript(this);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void removeItem(CollectableObjects collectedObject)
    {
        audioSource.Play();
        objectsToCollect.Remove(collectedObject);
        itemsList.text = "Objects to Collect:\n";
        for (int i = 0; i < objectsToCollect.Count; i++)
        {
            itemsList.text += objectsToCollect[i].gameObject.name + "\n";
        }
        if (objectsToCollect.Count == 0)
        {
            Debug.Log("All objects collected!");
            onWin.Invoke();
            //end level
        }
        onRemove.Invoke();
    }

    public void addItem(CollectableObjects collectableObject)
    {
        objectsToCollect.Add(collectableObject);
        itemsList.text = "Objects to Collect:\n";
        for (int i = 0; i < objectsToCollect.Count; i++)
        {
            itemsList.text += objectsToCollect[i].gameObject.name + "\n";
            objectsToCollect[i].setPlayer(player);
            objectsToCollect[i].setDistance(distanceFromPlayer);
            objectsToCollect[i].setCollectablesScript(this);
        }
    }
}
