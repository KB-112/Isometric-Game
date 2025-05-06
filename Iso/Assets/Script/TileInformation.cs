using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileInformation : MonoBehaviour
{
    [SerializeField] private TextMeshPro corrdiantes;
    Ray ray;
    [SerializeField] float heightofText;

    public Material highlightMaterial;
    Material newMaterial;

    // Keep a reference to the last highlighted object and its original material
    GameObject lastHighlightedObject = null;
    Material lastHighlightedObjectOriginalMaterial = null;

    private void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            CalculateCoordinates(hit);
            ObjectSelection(hit, Color.yellow);
        }
        else
        {
            corrdiantes.text = $" ";
            ClearHighlight();
        }
    }

    void CalculateCoordinates(RaycastHit hit)
    {
        corrdiantes.transform.position = hit.point;
        corrdiantes.transform.position = new Vector3(hit.transform.position.x, heightofText, hit.transform.position.z);
        corrdiantes.text = $"{hit.transform.position.x},{hit.transform.position.z}";
    }

    void ObjectSelection(RaycastHit hit, Color objectColor)
    {
        if (hit.collider != null && hit.collider.gameObject.CompareTag("Grid"))
        {
            ClearHighlight();

            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer != null && highlightMaterial != null)
            {
                // Save the original material of the new object to highlight
                lastHighlightedObjectOriginalMaterial = renderer.material;
                lastHighlightedObject = hit.collider.gameObject;

                newMaterial = new Material(highlightMaterial);
                renderer.material = newMaterial;
                newMaterial.color = objectColor;
            }
        }
    }

    // Restore the last highlighted object's material to its original material
    void ClearHighlight()
    {
        if (lastHighlightedObject != null)
        {
            Renderer renderer = lastHighlightedObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = lastHighlightedObjectOriginalMaterial;
            }

            lastHighlightedObject = null;
            lastHighlightedObjectOriginalMaterial = null;
        }
    }
}
