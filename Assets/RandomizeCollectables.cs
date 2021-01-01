using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collectables))]
public class RandomizeCollectables : MonoBehaviour
{
    [SerializeField]
    CollectableObjects[] objects;

    [SerializeField]
    int numberOfObjectsInScene;

    [SerializeField]
    Vector3 corner1;

    [SerializeField]
    Vector3 corner2;

    Collectables c;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        c = GetComponent<Collectables>();
        for(int i = 0; i < numberOfObjectsInScene; i++)
        {
            addObject();
        }
    }

    public void addObject()
    {
        CollectableObjects o = Instantiate(objects[Random.Range(0, objects.Length)]);
        o.gameObject.name=o.gameObject.name.Remove(o.gameObject.name.Length - 7);
        o.transform.position= new Vector3(Random.Range(Mathf.Min(corner1.x, corner2.x), Mathf.Max(corner1.x, corner2.x)), Random.Range(Mathf.Min(corner1.y, corner2.y), Mathf.Max(corner1.y, corner2.y)), Random.Range(Mathf.Min(corner1.z, corner2.z), Mathf.Max(corner1.z, corner2.z)));
        c.addItem(o);
    }
}
