using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 targetPosition;
    public StoreObstacleData obstacleData;
    List<Vector3> pathSlot = new List<Vector3>();
    public List<Vector3> pathMovementSlot = new List<Vector3>();
    public float speed = 0;
    Vector3 movement;
    int index = 0;
    int front, back, left, right = 0;
    private void Start()
    {
        InitTargetPosition();
        GridSlotAvailable();

        StartCoroutine(PlayerPath());






    }


    void InitTargetPosition()
    {
        targetPosition.y = 1.5f;
    }

    void GridSlotAvailable()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (!obstacleData.columns[i].rows[j])
                {
                    Vector3 pos = new Vector3(i, 1.5f, j);
                    pathSlot.Add(pos);
                }
            }
        }
    }

    void StepCalculation()
    {
        movement = new Vector3(transform.position.x + right + left, 1.5f, transform.position.z + front + back);


        if (FrontStep() < BackStep() || FrontStep() == BackStep())

        {
            front = 1;
            pathMovementSlot.Add(movement);

        }
        else if (BackStep() < FrontStep() )

        {
            back = -1;

            pathMovementSlot.Add(movement);

        }
        //else if (RightStep() < LeftStep() )

        //{
        //    right = 1;
        //    pathMovementSlot.Add(movement);
        //}
        //else if (LeftStep() < RightStep() )

        //{
        //    left = -1;
        //    pathMovementSlot.Add(movement);
        //}
    }

        void Step()
    {

        FrontStep();

        BackStep();
        Debug.Log("Front :" + FrontStep());
        Debug.Log("Back:" + BackStep());

    }

    int FrontStep()
    {
        
        return Mathf.Abs((int)(transform.position.z + 1) - (int)targetPosition.z);
    }

    int BackStep()
    {

        return Mathf.Abs((int)(transform.position.z - 1) - (int)targetPosition.z);
    }

    //int RightStep()
    //{

    //    return Mathf.Abs((int)(transform.position.x + 1) - (int)targetPosition.x);
    //}
    //int LeftStep()
    //{

    //    return Mathf.Abs((int)(transform.position.x - 1) - (int)targetPosition.x);
    //}

    IEnumerator PlayerPath()
    {
        while (true)
        {
           // Step();
           


           // StepCalculation();
            PathEstimaton();
           // transform.Translate(pathMovementSlot[index].x, 0, pathMovementSlot[index].z);
            //index++;
            yield return new WaitForSeconds(1f);


            yield return null;
        }
    }

    void PathEstimaton()
    {
        if(transform.position.z <= targetPosition.z  )
        {
            transform.Translate(0, 0, 1);
            Debug.Log("Front Direction");
        }
        else if(transform.position.z >= targetPosition.z)
        {
            transform.Translate(0, 0, -1);
            Debug.Log("Down Direction");
        }
        if(transform.position.x <= targetPosition.x)
        {
            transform.Translate(1, 0, 0);
            Debug.Log(" Right Direction");
        }
        else if (transform.position.x >= targetPosition.x)
        {
            transform.Translate(-1, 0, 0);
            Debug.Log("Left Direction");
        }
    }
}