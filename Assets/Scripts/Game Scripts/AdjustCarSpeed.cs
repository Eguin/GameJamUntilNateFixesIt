using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AdjustCarSpeed : MonoBehaviour
{
    [SerializeField]
    float minSpeed;

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    float changePerSecond;

    NavMeshAgent nma;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        nma = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nma.speed += Random.Range(-changePerSecond * Time.deltaTime, changePerSecond * Time.deltaTime);
        if (nma.speed < minSpeed)
        {
            nma.speed = minSpeed;
        }
        if (nma.speed > maxSpeed)
        {
            nma.speed = maxSpeed;
        }
    }
}
