using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CourseFinder : MonoBehaviour
{
    NavMeshAgent virus;
    public List<GameObject> destinations_A = new List<GameObject>();
    public List<GameObject> destinations_B = new List<GameObject>();
    public List<GameObject> course = new List<GameObject>();
    [SerializeField] float destinationSmooth = 1f;
    public int coursePos = 0;
    public float dist;
    void Start()
    {
        virus = GetComponent<NavMeshAgent>();
        virus.SetDestination(GameManager.i.Finish.transform.position);
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target_A"))
        {
            destinations_A.Add(target);
        }
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("Target_B"))
        {
            destinations_B.Add(target);
        }
        CreateCourse();
        virus.SetDestination(course[coursePos].transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        NextDestination();
    }

    void CreateCourse()
    {
        int A = Random.Range(0, destinations_A.Count);
        course.Add(destinations_A[A]);
        int B = Random.Range(0, destinations_B.Count);
        course.Add(destinations_B[B]);
        course.Add(GameManager.i.Finish);
    }

    void NextDestination()
    {
        dist = Vector3.Distance(transform.position, course[coursePos].transform.position);
        if (dist <= destinationSmooth)
        {
            if (!course[coursePos].CompareTag("End"))
            {
                coursePos++;
                virus.SetDestination(course[coursePos].transform.position);
            }
        }
    }
}
