using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
  public ObstacleManager obstacleManager;

    public GameObject obstaclePrefab;
    public GameObject tile2D;
    GridGeneration gridGeneration;
    public GameObject parentObject;
  
    

  
   public int distance;

    private void Start()
    {
        gridGeneration = GetComponent<GridGeneration>();
        obstacleManager.obstacle = obstaclePrefab;
        
        GridObstacleDeployment();
        
    }


    private void GridObstacleDeployment()
    {
        for (int i = 0; i <= gridGeneration.gridSize.x; i++)
        {
            for (int j = 0; j <= gridGeneration.gridSize.y; j++)
            {
                Vector3 tilePosition = new Vector3(-842 + (i * distance), -452 + (j * distance), 0);
                GameObject tile = Instantiate(tile2D, parentObject.transform, false);
                RectTransform rectTransform = tile.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = tilePosition;
            }
        }
    }


}
