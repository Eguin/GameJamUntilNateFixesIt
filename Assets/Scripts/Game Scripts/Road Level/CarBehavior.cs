using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarBehavior : MonoBehaviour
{
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float deltaSpeed;

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
        nma.speed += Random.Range(-deltaSpeed * Time.deltaTime, deltaSpeed * Time.deltaTime);
        if (nma.speed < minSpeed)
        {
            nma.speed = minSpeed;
        }
        if (nma.speed > maxSpeed)
        {
            nma.speed = maxSpeed;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Tunnel")){
            Destroy(gameObject);
        }
    }
}
