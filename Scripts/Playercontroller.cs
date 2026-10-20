using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Playercontroller : MonoBehaviour
{
    [SerializeField]
    private float force = 5;

    public Rigidbody2D rb;
    [SerializeField]
    private float maxSpeed = 4;

    private float elapsedTime = 0f;
    [SerializeField]

    private UIDocument uiDoc;

    private Label scoreLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private ParticleSystem explosionEffect;
    void Start()
    {
        scoreLabel = uiDoc.rootVisualElement.Q<Label>(); 
    }

    void UpdateScore()
    {
        elapsedTime += Time.deltaTime;
        scoreLabel.text = "Score: " + Mathf.FloorToInt(elapsedTime);
    }
    void UpdateMovement()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Debug.Log("The left button is clicked");
            Debug.Log("The current mouse position is: " + Mouse.current.position.value);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Debug.Log("The world posotion of the mouse is: " + mousePos);
            Vector2 dir = (mousePos - gameObject.transform.position).normalized;
            Debug.Log("The direction to the mouse is: " + dir.magnitude);
            transform.up = dir;
            rb.AddForce(dir * force);
            if (rb.linearVelocity.magnitude > maxSpeed);
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }
   
    //update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateMovement();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //transform.position;
        Destroy(gameObject);

    }
}
