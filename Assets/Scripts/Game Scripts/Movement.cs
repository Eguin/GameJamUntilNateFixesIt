using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float speed; //this is NOT change in speed per second, it's more complicated, but bigger is faster

    [SerializeField]
    float maxSpeed; //in m/s

    [SerializeField]
    float drag; //always perportional to speed

    [SerializeField]
    float maxWindForce;  //max force the wind can have per second

    [SerializeField]
    float windChangePerSecond; //MAX the wind can change per second, not guarenteed

    Vector3 windForce;

    //[SerializeField]
    //GameObject point;

    //[SerializeField]
    //GameObject cam;


    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        rb = GetComponent<Rigidbody>();
        windForce = new Vector3(Random.Range(-maxWindForce / 4, maxWindForce / 4), 0, Random.Range(-maxWindForce / 4, maxWindForce / 4));
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        float theta = transform.eulerAngles.y;

        if (Input.GetKey("w"))
        {
            transform.eulerAngles = new Vector3(0, Mathf.Lerp(theta, 0, .2f), 0);
        }

        if (Input.GetKey("a"))
        {
            transform.eulerAngles = new Vector3(0, Mathf.Lerp(theta, (Mathf.PI / 2), .2f), 0);
        }

        if (Input.GetKey("d"))
        {
            this.transform.eulerAngles = new Vector3(0, Mathf.Lerp(theta, ((Mathf.PI / 2) * 3), .2f), 0);
        }
        if (Input.GetKey("s"))
        {
            this.transform.eulerAngles = new Vector3(0, Mathf.Lerp(theta, Mathf.PI, .2f), 0);
        }




        //cam.transform.position = new Vector3(transform.position.x - 7f, transform.position.y + 4.23f, transform.position.z);
        //point.transform.eulerAngles = new Vector3(0,0,theta * 57.3f);


        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            rb.AddForce(Mathf.Cos(theta)*speed*time, 0, Mathf.Sin(theta)*speed*time);
        }


        //wind force
        windForce.x += Random.Range(-windChangePerSecond,windChangePerSecond) * time;
        windForce.z += Random.Range(-windChangePerSecond, windChangePerSecond) * time;

        if (Vector3.Magnitude(windForce) > maxWindForce)
        {
            windForce = Vector3.ClampMagnitude(windForce, maxWindForce);
        }

        rb.AddForce(windForce*time);

        //drag force
        rb.AddForce(-rb.velocity * drag *time);

        //keeps the speed at a max
        if (Vector3.Magnitude(rb.velocity) > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }



    }
}