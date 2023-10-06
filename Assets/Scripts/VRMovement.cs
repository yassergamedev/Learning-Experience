using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private bool isMoving = false;
 
  

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.W))
        {
            // Check for touch, space key press, remote button click, or "W" key press
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    isMoving = true;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isMoving = false;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1") || Input.GetKey(KeyCode.W))
            {
                isMoving = true;
            }
        }
        else if (Input.touchCount == 0 && Input.GetKeyUp(KeyCode.Space) && !Input.GetKey(KeyCode.W))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (CanMove())
            {
                MovePlayer();
            }
            else
            {
                isMoving = false;
            }
        }
    }

    private void MovePlayer()
    {
        // Move the player character in the direction that the camera is facing
        transform.Translate(Camera.main.transform.forward * moveSpeed * Time.deltaTime);
    }

    private bool CanMove()
    {
        // Cast a ray from the camera's position in the forward direction
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        // Set the ray's length to limit movement distance
        float maxRayLength = .5f; // Adjust this value as needed

        // Update the LineRenderer to visualize the ray
    
        // Check if the ray hits any colliders within the specified length
        if (Physics.Raycast(ray, out hit, maxRayLength))
        {
            // Player can't move because the ray hit a collider
            return false;
        }

        // Player can move because there are no obstacles in the path
        return true;
    }
}
