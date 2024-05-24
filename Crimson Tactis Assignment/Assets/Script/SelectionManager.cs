using UnityEngine;
using System;

public class SelectionManager : MonoBehaviour
{
    public static event Action<GameObject> mouseInput;
    public static event Action removeMouse;

    [SerializeField] private string selectableGrid = "";

    private GameObject currentSelection = null;

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var _selection = hit.transform;
            if (_selection.CompareTag(selectableGrid))
            {
                if (currentSelection != null && currentSelection != _selection.gameObject)
                {
                    removeMouse?.Invoke();
                }

                currentSelection = _selection.gameObject;
                mouseInput?.Invoke(currentSelection);
            }
        }
        else if (currentSelection != null)
        {
            removeMouse?.Invoke();
            currentSelection = null;
        }
    }
}
