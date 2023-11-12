using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum State
{
    Idle,
    Moving
}

public class CatMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private float maxIdleTime;
    [SerializeField]
    private float maxTravelDistance;
    [SerializeField]
    private float speed;

    private State state;
    private float idleTimer;

    // Update is called once per frame
    void Update()
    {
        if (state != State.Idle)    // If cat is ready to move
        {
            if (!agent.hasPath)
                SearchWalkPoint();
            else  // If cat found a valid destination
            {
                var distanceLeftSqr = (agent.destination - gameObject.transform.position).sqrMagnitude;
                if (distanceLeftSqr < 1)
                {
                    agent.ResetPath();
                    state = State.Idle;
                    idleTimer = Random.Range(0, maxIdleTime);
                }
            }
        }
        else if (state == State.Idle)
        {
            idleTimer -= Time.deltaTime;
            if (idleTimer <= 0f)
            {
                state = State.Moving;
            }
        }
    }

    // Aligning destination directly onto navmesh terrain to avoid bugs
    void SearchWalkPoint()
    {
        Vector3 location = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up) * Vector3.forward * Random.Range(0, maxTravelDistance);
        RaycastHit hit;
        if (Physics.Raycast(location + Vector3.down * 1000, transform.up, out hit) || Physics.Raycast(location + Vector3.up * 1000, -transform.up, out hit))
        {
            if (hit.collider.gameObject.tag.Equals("Ground"))
            {
                agent.SetDestination(hit.point);
                state = State.Moving;
            }
        }
    }
}
