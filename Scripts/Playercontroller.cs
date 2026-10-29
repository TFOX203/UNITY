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

    [SerializeField]
    private ParticleSystem explosionEffect;
    [SerializeField]

    private AudioSource audioSource;

    private void Start()
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
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 dir = (mousePos - (Vector2)transform.position).normalized;

            transform.up = dir;
            rb.AddForce(dir * force);

            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        UpdateMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        // Punto exacto del choque (si no hay contactos, usa la posición del jugador)
        Vector2 hitPoint = collision.contactCount > 0
            ? collision.contacts[0].point
            : (Vector2)transform.position;

        Instantiate(explosionEffect, hitPoint, Quaternion.identity);
        Destroy(gameObject);
    }
}