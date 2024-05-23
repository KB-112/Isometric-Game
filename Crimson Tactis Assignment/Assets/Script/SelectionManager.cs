using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;
    Color deselectColor = new Color(255f, 255f, 255f, 255f);

    [SerializeField] private string selectableGrid = "";

    private Transform selection;
    private void Update()
    {
        if (selection != null)
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material.color = deselectColor;
            }
            selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var _selection = hit.transform;
            if (_selection.CompareTag(selectableGrid))
            {
                var selectionRenderer = _selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material.color = highlightMaterial.color;
                }
                selection = _selection;
            }
        }
    }

}
