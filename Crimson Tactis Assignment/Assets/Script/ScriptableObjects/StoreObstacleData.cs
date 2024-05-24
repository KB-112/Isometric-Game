
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="ObstacleData" ,menuName ="Obstacle")]
public class StoreObstacleData : ScriptableObject
{
    public int X;
    public int Y;
    public Column[] columns;
    
    public void ResizeGrid(int newX, int newY)
    {
        X = newX;
        Y = newY;
        columns = new Column[X];
        for (int i = 0; i < X; i++)
        {
            columns[i] = new Column(Y);
        }
    }

   

}

[System.Serializable]
public class Column
{
    public bool[] rows;

    public Column(int size)
    {
        rows = new bool[size];
    }
}




