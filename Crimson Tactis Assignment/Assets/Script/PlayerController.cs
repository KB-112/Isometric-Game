using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 targetPosition;
    public StoreObstacleData obstacleData;
    List<Vector3> pathSlot = new List<Vector3>();
    public List<Vector3> pathMovementSlot = new List<Vector3>();
    public float speed = 1.0f; // Set a default speed
    Vector3 movement;
    int index = 0;

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
        int frontStep = FrontStep();
        int backStep = BackStep();

        if (frontStep < backStep)
        {
            movement = new Vector3(transform.position.x, 1.5f, transform.position.z + 1);
        }
        else if (backStep < frontStep)
        {
            movement = new Vector3(transform.position.x, 1.5f, transform.position.z - 1);
        }
        else
        {
            // Default case, just in case both steps are equal
            movement = transform.position;
        }

        pathMovementSlot.Add(movement);
    }

    int FrontStep()
    {
        return Mathf.Abs((int)(transform.position.z + 1) - (int)targetPosition.z);
    }

    int BackStep()
    {
        return Mathf.Abs((int)(transform.position.z - 1) - (int)targetPosition.z);
    }

    IEnumerator PlayerPath()
    {
        while (index < pathMovementSlot.Count || (transform.position != targetPosition))
        {
            StepCalculation();

            while (Vector3.Distance(transform.position, pathMovementSlot[index]) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, pathMovementSlot[index], speed * Time.deltaTime);
                yield return null;
            }

            index++;
            yield return new WaitForSeconds(1f);
        }
    }
}
