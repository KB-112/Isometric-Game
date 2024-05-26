using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public float speed = 5f;
    public float reachDistance = 1f; 

    private List<Vector3> targets = new List<Vector3>();
    private int currentTargetIndex = 0;
   [SerializeField] private Vector3 targetPosition;

    private void Start()
    {
    
        StepCount();
        if (targets.Count > 0)
        {
            targetPosition = targets[0]; 
        }
    }

    private void Update()
    {
        MoveToTarget();
    }

   

    void MoveToTarget()
    {
        if (targets.Count == 0) return;

        if (Vector3.Distance(transform.position, targetPosition) <= reachDistance)
        {
            currentTargetIndex++;

            if (currentTargetIndex >= targets.Count)
            {
                return;
            }

            targetPosition = targets[currentTargetIndex];
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void StepCount()
    {
        float totalnumberofStepsX = Mathf.Abs(transform.position.x - targetPosition.x);
        float totalnumberofStepsZ = Mathf.Abs(transform.position.z - targetPosition.z);

        Debug.Log("Y: " + totalnumberofStepsZ);
        Debug.Log("X: " + totalnumberofStepsX);

        targets.Add(new Vector3(transform.position.x + totalnumberofStepsX, 1.5f, transform.position.z));
        targets.Add(new Vector3(transform.position.x + totalnumberofStepsX, 1.5f, transform.position.z + totalnumberofStepsZ));
    }
}

//for (int i = 0; i < obstacleData.X; i++)
//{
//    for (int j = 0; j < obstacleData.Y; j++)
//    {
//        if (obstacleData.columns[i].rows[j] && i< totalnumberofStepsZ)
//        {
//            obsPos.Add(new Vector3(i, 1, j));

//        }
//    }
//}