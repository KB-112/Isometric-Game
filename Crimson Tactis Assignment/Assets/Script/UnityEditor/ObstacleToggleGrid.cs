using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StoreObstacleData))]
public class ObstacleToggleGrid : Editor
{
    StoreObstacleData targetStoreObstacleData;
   
    bool hasUnsavedChanges;
    private Vector2 scrollPosition;

    void OnEnable()
    {
        targetStoreObstacleData = (StoreObstacleData)target;
       
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

     
       

        using (new EditorGUI.DisabledScope(hasUnsavedChanges))
        {
            if (GUILayout.Button("Create unsaved changes"))
                hasUnsavedChanges = true;
        }

        using (new EditorGUI.DisabledScope(!hasUnsavedChanges))
        {
            if (GUILayout.Button("Save"))
                SaveChanges();

            if (GUILayout.Button("Discard"))
                DiscardChanges();
        }

        int newX = EditorGUILayout.IntField(targetStoreObstacleData.X);
        int newY = EditorGUILayout.IntField(targetStoreObstacleData.Y);

        if (newX != targetStoreObstacleData.X || newY != targetStoreObstacleData.Y)
        {
            targetStoreObstacleData.ResizeGrid(newX, newY);
            hasUnsavedChanges = true;
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

                bool newValue = EditorGUILayout.Toggle(targetStoreObstacleData.columns[x].rows[y], GUILayout.MaxHeight(10));
                if (newValue != targetStoreObstacleData.columns[x].rows[y])
                {
                    Undo.RecordObject(targetStoreObstacleData, "Toggle Change");
                    targetStoreObstacleData.columns[x].rows[y] = newValue;
                    hasUnsavedChanges = true;
                }
                GUILayout.Space(20);
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndScrollView();

        serializedObject.ApplyModifiedProperties();
    }

    private void SaveChanges()
    {
      
        EditorUtility.SetDirty(targetStoreObstacleData);
        AssetDatabase.SaveAssets();
        hasUnsavedChanges = false;

        Debug.Log($"{this} saved successfully!!!");
    }

    private void DiscardChanges()
    {
       
        Undo.PerformUndo();
        hasUnsavedChanges = false;
        
        Debug.Log($"{this} discarded changes!!!");
    }

  
}
