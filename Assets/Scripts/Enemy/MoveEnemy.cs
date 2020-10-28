using UnityEngine;
using UnityEngine.AI;


public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject[] allPoint; // все точки для перемещения врага
    private GameObject Target; // точка Point куда двигается враг


    private void Start()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        int randomPoint = Random.Range(0, allPoint.Length);
        agent.SetDestination(allPoint[randomPoint].transform.position);
        Target = allPoint[randomPoint];
    }



    private void Update()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) <= 1f)
        {
            MoveToPoint();
        }
    }

}