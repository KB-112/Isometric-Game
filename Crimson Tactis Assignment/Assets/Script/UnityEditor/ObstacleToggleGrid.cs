using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StoreObstacleData))]
public class ObstacleToggleGrid : Editor
{
    StoreObstacleData targetStoreObstacleData;

    void OnEnable()
    {
        targetStoreObstacleData = (StoreObstacleData)target;
    }

    private Vector2 scrollPosition;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        int newX = EditorGUILayout.IntField(targetStoreObstacleData.X);
        int newY = EditorGUILayout.IntField(targetStoreObstacleData.Y);

        if (newX != targetStoreObstacleData.X || newY != targetStoreObstacleData.Y)
        {
            targetStoreObstacleData.ResizeGrid(newX, newY);
        }

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

        EditorGUILayout.BeginHorizontal();
        for (int y = 0; y < targetStoreObstacleData.Y; y++)
        {
            EditorGUILayout.BeginVertical();
            for (int x = 0; x < targetStoreObstacleData.X; x++)
            {
                string pos = x.ToString() + "," + y.ToString();
                GUIContent gUIContent = new GUIContent(pos);

                EditorGUILayout.LabelField(gUIContent.text, GUILayout.MaxWidth(20));
                GUILayout.FlexibleSpace();

                targetStoreObstacleData.columns[x].rows[y] = EditorGUILayout.Toggle(targetStoreObstacleData.columns[x].rows[y], GUILayout.MaxHeight(10));
                GUILayout.Space(20);
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();
      
        EditorGUILayout.EndScrollView();

        serializedObject.ApplyModifiedProperties();
    }


}
