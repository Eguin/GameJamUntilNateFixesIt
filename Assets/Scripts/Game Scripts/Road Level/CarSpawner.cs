using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] carsPrefab;
    [SerializeField] Transform[] spawnPoints = new Transform[8];

    private Vector3[] endPoints = new Vector3[]{
        new Vector3(47, 0, 245),
        new Vector3(40, 0, -40),
        new Vector3(27, 0, 245),
        new Vector3(20, 0, -40),
        new Vector3(3, 0, 245),
        new Vector3(-4, 0, -40),
        new Vector3(-16, 0, 245),
        new Vector3(-24, 0, -40),
    };

    private GameObject[] cars = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {
        //pick random number of starting cars in range
        int startingCars = Random.Range(4, 9);
        //get spawn points for cars
        Transform[] spawns = ChooseSet(startingCars);
        foreach (Transform spawn in spawns)
        {
            //pick random color for cars.
            int carColor = Random.Range(0,4);
            //get current index of spawn in spawnPoints so we know which lane is in use
            int currentIndex = ArrayUtility.IndexOf(spawnPoints, spawn);
            cars[currentIndex] = Instantiate(carsPrefab[carColor], spawn) as GameObject;
            cars[currentIndex].GetComponent<NavMeshAgent>().SetDestination(endPoints[currentIndex]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get the empty lanes and spawn a car in them
        foreach(int lane in getEmptyLanes()){
            int carColor = Random.Range(0,3);
            cars[lane] = Instantiate(carsPrefab[carColor], spawnPoints[lane]) as GameObject;
            cars[lane].GetComponent<NavMeshAgent>().SetDestination(endPoints[lane]);
        }
    }

    /*  Chooses a semi-random set (size of numRequired) of spawn points from spawnPoints
        taken from https://docs.unity3d.com/Manual/class-Random.html under "Choosing from a Set of Items Without Repitition" */
    Transform[] ChooseSet(int numRequired)
    {
        Transform[] result = new Transform[numRequired];

        int numToChoose = numRequired;

        for (int numLeft = spawnPoints.Length; numLeft > 0; numLeft--)
        {
            float prob = (float)numToChoose / (float)numLeft;

            if (Random.value <= prob)
            {
                numToChoose--;
                result[numToChoose] = spawnPoints[numLeft - 1];

                if (numToChoose == 0)
                {
                    break;
                }
            }
        }
        return result;
    }

    //returns indexes of empty lanes
    List<int> getEmptyLanes(){
        List<int> result = new List<int>();
        for(int i = cars.Length-1; i >= 0; i--){
            if(cars[i] == null){
                result.Add(i);
            }
        }
        return result;
    }
}