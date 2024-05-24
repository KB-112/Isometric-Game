using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TileInfo : MonoBehaviour
{
    [SerializeField] private TextMeshPro corrdiantes;

    Color deselectColor = new Color(255f, 255f, 255f, 255f);
    [SerializeField] private Material selectionMaterial;
    private GameObject selectTile;

    private void Start()
    {
        SelectionManager.mouseInput += Information;
        SelectionManager.removeMouse += ChangeInfo;
    }

    void Information(GameObject selectedTile)
    {
        if (selectedTile == this.gameObject)
        {
            selectTile = selectedTile;
            corrdiantes.text = $"X: {this.transform.position.x}, Y: {this.transform.position.z}";
            Material newMaterial = new Material(selectionMaterial);
            newMaterial.color = new Color(255f, 92f, 0f, 255f);

            
            this.GetComponent<Renderer>().material = newMaterial;

        }
    }

    void ChangeInfo()
    {
        if (selectTile == this.gameObject)
        {
            corrdiantes.text = $" ";
            this.GetComponent<Renderer>().material = selectionMaterial;
            selectionMaterial.color = deselectColor;
        }
    }
    private void OnDestroy()
    {
        SelectionManager.mouseInput -= Information;
    }
}
