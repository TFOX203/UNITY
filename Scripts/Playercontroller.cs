using UnityEngine;
using UnityEngine.InputSystem;

public class Playercontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log("The left button is clicked");
            Debug.Log("The current mouse position is: " + Mouse.current.position.value);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Debug.Log("The world posotion of the mouse is: " + mousePos);
            Vector2 dir = mousePos - gameObject.transform.position;
            Debug.Log("The direction to the mouse is: " + dir);
        }
    }
}
