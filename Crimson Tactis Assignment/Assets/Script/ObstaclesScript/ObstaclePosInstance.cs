using System.Collections.Generic;
using UnityEngine;


public class ObstaclePosInstance : MonoBehaviour
{
    
    public static ObstaclePosInstance instance;
  [HideInInspector] public List<Vector3> pos = new List<Vector3>();
    public StoreObstacleData obstacleData; 

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        AvailablePos();
    }
    void AvailablePos()
    {
        for (int i = 0; i < obstacleData.X; i++)
        {
            for (int j = 0; j < obstacleData.Y; j++)
            {
                if (!obstacleData.columns[i].rows[j])
                {
                    pos.Add(new Vector3(i, 1, j));
                }
            }
        }
    }
}
