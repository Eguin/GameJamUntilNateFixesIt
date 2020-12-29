using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class Infection : MonoBehaviour {

    [SerializeField]
    SphereCollider virusSphere;

    [SerializeField]
    float gettingInfectedRadius;

    [SerializeField]
    float infectingRadius;

    [SerializeField]
    float randomVariableOffset;
    //this variable is the odds of the person getting infected per frame with the chance being this variable/the distance between the 2 people

    [SerializeField]
    UnityEvent onInfected;

    [SerializeField]
    bool isInfected=false;

    bool onlyOnce=true;

    private void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        virusSphere.radius = gettingInfectedRadius;
    }

    private void Update()
    {
        if (isInfected&&onlyOnce)
        {
            setInfected();
            onlyOnce = false;
        }
        if(!isInfected)
        {
            virusSphere.radius = gettingInfectedRadius;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isInfected)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Person"))
            {
                //Debug.Log("Entered Radius");
                if (!other.gameObject.GetComponent<Infection>().getInfected())
                {
                    //Debug.Log("Possibility to infect: " + randomVariableOffset / Vector3.Distance(transform.position, other.transform.position));
                    float probability = Random.Range(0f, Vector3.Distance(transform.position, other.transform.position));
                    if(probability> Vector3.Distance(transform.position, other.transform.position) - randomVariableOffset)
                    {
                        other.gameObject.GetComponent<Infection>().setInfected();
                        //Debug.Log("Infected!");
                    }
                }
            }
        }
    }

    public void setInfected()
    {
        isInfected = true;
        virusSphere.radius = infectingRadius;
        //gameObject.GetComponent<Renderer>().material.color = Color.red;
        onInfected.Invoke();
        ScoreHandler.infected++;
    }

    public bool getInfected()
    {
        return isInfected;
    }
}
