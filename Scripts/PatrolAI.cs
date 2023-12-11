using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    int currentPatrolPositionIndex;
    float currrentWaitingTime;
    float maxWaitingTime;
    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        
        currentPatrolPositionIndex = -1;
        currrentWaitingTime= 0;
        maxWaitingTime = 0;

        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.remainingDistance < 0.5f){

            if(maxWaitingTime == 0){
                maxWaitingTime = Random.Range(0,3);
            }
            if(currrentWaitingTime >= maxWaitingTime){
                maxWaitingTime = 0;
                currrentWaitingTime = 0;
                GoToNextPoint();
            }
            else{
                currrentWaitingTime += Time.deltaTime;
            }
        }
    }

    void GoToNextPoint(){
        if(patrolPoints.Length != 0){
            currentPatrolPositionIndex = (currentPatrolPositionIndex + 1) % patrolPoints.Length;
            nav.SetDestination(patrolPoints[currentPatrolPositionIndex].position);
        }
    }
}
