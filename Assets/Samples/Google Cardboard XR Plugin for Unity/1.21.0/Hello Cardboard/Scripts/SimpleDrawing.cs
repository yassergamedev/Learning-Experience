using UnityEngine;
using UnityEngine.UI;

public class SimpleDrawing : MonoBehaviour
{
    public Text drawingText; // Reference to the Text component on the Canvas
    private bool isDrawing = false;
    private Vector2 lastPos;

    private void Update()
    {
        // Check for mouse button down to start drawing
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            lastPos = Input.mousePosition;
        }

        // Check for mouse button up to stop drawing
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }

        // If drawing, update the text with the drawn content
        if (isDrawing)
        {
            Vector2 currentPos = Input.mousePosition;

            // Check if the mouse position has changed significantly
            if (Vector2.Distance(currentPos, lastPos) > 1f)
            {
                // Convert mouse position to canvas space
                RectTransform canvasRectTransform = drawingText.canvas.GetComponent<RectTransform>();
                Vector2 localPos;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, currentPos, null, out localPos);

                // Update the text content with the drawn content
                drawingText.text += "\n" + localPos.ToString();

                // Update the last position
                lastPos = currentPos;
            }
        }
    }
}
