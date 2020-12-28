using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SetPersonDestination : MonoBehaviour
{
    static int randomSeed = 0;
    NavMeshAgent nma;

    [SerializeField]
    Vector3[] destinations=new Vector3[2];

    [SerializeField]
    bool randomizeTwoPositionsInRange;

    [SerializeField]
    Vector3 corner1;

    [SerializeField]
    Vector3 corner2;
    //the agent will loop between his destinations

    int index = 0;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        Random.InitState((int)System.DateTime.Now.Ticks+randomSeed);
        randomSeed++;

        if (randomizeTwoPositionsInRange)
        {
            destinations = new Vector3[2];
            destinations[0] = new Vector3(Random.Range(Mathf.Min(corner1.x, corner2.x), Mathf.Max(corner1.x, corner2.x)), Random.Range(Mathf.Min(corner1.y, corner2.y), Mathf.Max(corner1.y, corner2.y)), Random.Range(Mathf.Min(corner1.z, corner2.z), Mathf.Max(corner1.z, corner2.z)));
            destinations[1] = new Vector3(Random.Range(Mathf.Min(corner1.x, corner2.x), Mathf.Max(corner1.x, corner2.x)), Random.Range(Mathf.Min(corner1.y, corner2.y), Mathf.Max(corner1.y, corner2.y)), Random.Range(Mathf.Min(corner1.z, corner2.z), Mathf.Max(corner1.z, corner2.z)));
            transform.position = destinations[1];
        }
        nma.destination = destinations[0];
        //transform.position = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
        //StartCoroutine(SetNewDest());
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, nma.destination) < 1)
        {
            index++;
            if (index >= destinations.Length) index = 0;
            nma.destination = destinations[index];
        }
    }

    /*IEnumerator SetNewDest()
    {
        nma.destination = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
        yield return new WaitForSeconds(Random.Range(3f,6f));
        StartCoroutine(SetNewDest());
    }*/
}
