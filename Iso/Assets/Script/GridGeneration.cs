using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GridGeneration : MonoBehaviour
{
    public  Vector2 gridSize;
    Vector3 posofGrid;
    public GameObject gridObj;

    Vector2 distance;
    private void Start()
    {
        distance = gridObj.transform.localScale;
      
        CreateLayout();
    }


    void CreateLayout()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            { 
                posofGrid = new Vector3(i*distance.x, 0,j*distance.y);
         GameObject obj =     Instantiate(gridObj, posofGrid, Quaternion.identity);
                
             
            }
        }
    }
}
