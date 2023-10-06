using UnityEngine;
using UnityEngine.UI;

public class DrawingCanvas : MonoBehaviour
{
    public RectTransform canvasRectTransform; // Reference to the RectTransform of the canvas
    public GameObject brushPrefab; // Reference to a brush prefab
    public Color brushColor = Color.black;
    public float brushSize = 10f;

    private GameObject currentBrush;
    private Vector2 lastPosition;

    private void Update()
    {
        // Check for touch or mouse input
        if (Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            Vector2 currentPosition = Input.mousePosition;

            // Check if the mouse/touch position is inside the canvas
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, currentPosition, null, out Vector2 localPosition))
            {
                if (currentBrush == null)
                {
                    CreateBrush(localPosition);
                }
                else
                {
                    DrawBrush(localPosition);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            DestroyBrush();
        }
    }

    private void CreateBrush(Vector2 position)
    {
        currentBrush = Instantiate(brushPrefab, canvasRectTransform);
        currentBrush.GetComponent<Image>().color = brushColor;
        currentBrush.transform.localPosition = position;
        lastPosition = position;
    }

    private void DrawBrush(Vector2 position)
    {
        Vector2 direction = position - lastPosition;
        float distance = direction.magnitude;

        if (distance > 0)
        {
            direction.Normalize();

            for (float i = 0; i < distance; i += 0.5f)
            {
                Vector2 interpolatedPosition = lastPosition + direction * i;
                GameObject brushStroke = Instantiate(brushPrefab, canvasRectTransform);
                brushStroke.GetComponent<Image>().color = brushColor;
                brushStroke.transform.localPosition = interpolatedPosition;
                brushStroke.transform.localScale = Vector3.one * brushSize / 100f;
            }

            lastPosition = position;
        }
    }

    private void DestroyBrush()
    {
        Destroy(currentBrush);
        currentBrush = null;
    }
}
