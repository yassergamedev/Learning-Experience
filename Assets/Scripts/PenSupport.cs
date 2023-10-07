using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PenSupport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Pen.current.displayName);
    }

    // Update is called once per frame
    void Update()
    {
        if(Pen.current.tip.isPressed)
        {
            Debug.Log("Pen Is Pressed");
        }

        if(Pen.current.tip.wasPressedThisFrame)
        {
            Debug.Log("Pen was Touched this frame");
        }
        if (Pen.current.firstBarrelButton.wasPressedThisFrame)
        {
            Debug.Log("forst Touched this frame");
        }

    }
}
