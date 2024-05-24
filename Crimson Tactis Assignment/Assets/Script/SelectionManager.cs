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
            if (currentSelection != null && currentSelection != _selection.gameObject)
            {
                Debug.Log("Hit");
                if (removeMouse != null)
                    removeMouse.Invoke();
            }

            if (currentSelection != null)
            {
                if (mouseInput != null)
                    mouseInput.Invoke(currentSelection);
            }

        }
        else if (currentSelection != null)
        {
            if (removeMouse != null)
                removeMouse.Invoke();
            currentSelection = null;
        }

    }
}
