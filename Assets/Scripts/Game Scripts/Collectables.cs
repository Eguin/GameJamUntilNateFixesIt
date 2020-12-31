using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

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
    TextMeshProUGUI itemsList;

    [SerializeField]
    UnityEvent onWin;
    
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        itemsList.text = "";
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
        itemsList.text = "";
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
    }
}
