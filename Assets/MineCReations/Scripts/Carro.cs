using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Carro : MonoBehaviour
{

    private NavMeshAgent car;

    public List<Transform> patrol = new List<Transform>();
    public int current = 0;

    private Rigidbody rb;

    public Transform garage;

    bool flag;

    public int death;

    void Start()
    {

        car = GetComponent<NavMeshAgent>();

        rb = GetComponent<Rigidbody>();

        rb.isKinematic = false;

        flag = false;

        death = 0;

    }

    void Update()
    {
        
        if (flag == true)
        {

            car.SetDestination(garage.position);
            rb.isKinematic = true;

        }
        else
        {

                if (death == 5)
                {

                    flag = true;

                }

            MoveToNextPoint();

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "CelulaEnergetica")
        {

            Destroy(other.gameObject);

            death++;
           
        }

    }

    void MoveToNextPoint()
    {
        if (patrol.Count > 0)
        {
            float distance = Vector3.Distance(patrol[current].position, transform.position);
            car.destination = patrol[current].position;

            if (distance <= 0.5f)
            {

                current = Random.Range(0, patrol.Count);
                current %= patrol.Count;

            }
        }
    }
  
}