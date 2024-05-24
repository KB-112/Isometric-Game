
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlockGeneration : MonoBehaviour
{
    public TextMeshProUGUI coordinatesText;
    public GameObject enemySpawn;
    public Button currentBtn;

    private Vector2Int currentCoordinates;

    void Start()
    {
        currentCoordinates = ParseCoordinates(coordinatesText.text);
        currentBtn.onClick.AddListener(OnBtnPress);
    }

    void OnBtnPress()
    {
        if (currentBtn.image.color == Color.white)
        {
            currentBtn.image.color = Color.yellow;
            Instantiate(enemySpawn, new Vector3(currentCoordinates.x,1 ,currentCoordinates.y), Quaternion.identity);
        }
        else
        {
            currentBtn.image.color = Color.white;
           
        }
    }

    Vector2Int ParseCoordinates(string coordinateText)
    {
        string[] parts = coordinateText.Split(',');
        if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
        {
            return new Vector2Int(x, y);
        }
        else
        {
            Debug.LogError("Invalid coordinate format!");
            return Vector2Int.zero;
        }
    }
}
