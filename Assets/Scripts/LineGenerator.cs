using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;

    Line activeLine;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();
        }
        if(Input.GetMouseButtonUp(0))
        {
            activeLine = null;
            
        }
        if(activeLine != null)
        {
            Vector2 penPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(penPos);
        }
    }
}
