
using TMPro;

using UnityEngine;

public class Obstacles : MonoBehaviour
{
  public ObstacleManager obstacleManager;

    public GameObject obstaclePrefab;
    public GameObject tile2D;
    GridGeneration gridGeneration;
    public GameObject parentObject;
     TextMeshProUGUI coordinatesText;
    

  
   public int distance;
    public int widthX = 0;
    public int heightY = 0;
    private void Start()
    {
        gridGeneration = GetComponent<GridGeneration>();
       
        
        GridObstacleDeployment();
        
    }


    private void GridObstacleDeployment()
    {
        for (int i = 0; i < gridGeneration.gridSize.x; i++)
        {
            for (int j = 0; j < gridGeneration.gridSize.y; j++)
            {
               coordinatesText= tile2D.GetComponentInChildren<TextMeshProUGUI>();
                coordinatesText.text = $"{i},{j}" ;
                Vector3 tilePosition = new Vector3(-842 + (i * distance), -452 + (j * distance), 0);
                GameObject tile = Instantiate(tile2D, parentObject.transform, false);
                RectTransform rectTransform = tile.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = tilePosition;
            }
        }
    }


}
