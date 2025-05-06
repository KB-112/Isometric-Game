using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public StoreObstacleData obstacleData;
    public GameObject obstaclePrefab;
   
    public  List<Vector3> pos;


    private void Start()
    {
        CheckActiveBools();
    }

    public void CheckActiveBools()
    {
        pos = new List<Vector3>();

        for (int i = 0; i < obstacleData.X; i++)
        {
            for (int j = 0; j < obstacleData.Y; j++)
            {
                if (obstacleData.columns[i].rows[j])
                {
                  //  Debug.Log("Bool at column " + i + ", row " + j + " is active.");
                   
                    pos.Add(new Vector3(i, 1,j)); 
                }
            }
        }

       
        for(int i =0; i < pos.Count;i++)
        {
            Instantiate(obstaclePrefab, pos[i], Quaternion.identity);
        }
    }
   
}
