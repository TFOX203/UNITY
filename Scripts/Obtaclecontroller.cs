using UnityEngine;

public class Obtaclecontroller : MonoBehaviour
{
    [SerializeField]
    private float minSize = 2.5f;
    [SerializeField]
    private float maxSize = 3f;
    [SerializeField]
    private float minForce = 20f;
    [SerializeField]
    private float maxForce = 48f;
    [SerializeField]
    private float minTorque = 20f;
    [SerializeField]
    private float maxTorque = 48f;

    [SerializeField]
    private ParticleSystem impactEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Assign a random size to each obstacle object
        float size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(size, size, 1);

        // Get the rigidbody component on our game object
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector2 randomDirection = Random.insideUnitCircle;

        // Generate a random force
        float force = Random.Range(minForce, maxForce);
        rb.AddForce(randomDirection * force);

        // Apply a random torque for each obstacle
        float torque = Random.Range(minTorque, maxTorque);
        rb.AddTorque(-torque);

        rb.mass = size * 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (impactEffect == null || collision.contactCount == 0) return;

        // Punto exacto del choque
        Vector2 hitPoint = collision.contacts[0].point;
        Instantiate(impactEffect, hitPoint, Quaternion.identity);
    }
}