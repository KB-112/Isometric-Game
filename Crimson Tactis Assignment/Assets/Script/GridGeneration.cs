using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GridGeneration : MonoBehaviour
{
    public Vector2 gridSize;
    Vector2 posofGrid;
    public GameObject gridObj;
    public Text posInput;

    private void Start()
    {
       CreateLayout();
    }


    void CreateLayout()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            { 
                posofGrid = new Vector2(i, i);
         GameObject obj =     Instantiate(gridObj, posofGrid, Quaternion.identity);
                
             
            }
        }
    }
}
