using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GridGeneration : MonoBehaviour
{
    public Vector2 gridSize;
    Vector3 posofGrid;
    public GameObject gridObj;
   

    private void Start()
    {
       CreateLayout();
    }


    void CreateLayout()
    {
        for (int i = 2; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            { 
                posofGrid = new Vector3(i, 0,j);
         GameObject obj =     Instantiate(gridObj, posofGrid, Quaternion.identity);
                
             
            }
        }
    }
}
