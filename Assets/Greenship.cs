using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greenship : MonoBehaviour
{
    public float runSpeed;

    public Rigidbody2D body;

    float horizontalAccel = 0;
    float verticalAccel = 0;
    float horizontalVel = 0;
    float verticalVel = 0;
    float maxSpeed = 20;
    float energy = 10;
    float blueness = 0;
    bool spaceReset = true;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Destroy(SpriteRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAccel = Input.GetAxis("Horizontal") * .4f;
        verticalAccel = Input.GetAxis("Vertical") * .4f;

        // If you're going in the opposite direction, change course faster
        if (horizontalAccel * horizontalVel < 1) {
            horizontalAccel *= 2.5f;
        }

        if (verticalAccel * verticalVel < 1) {
            verticalAccel *= 2.5f;
        }

        horizontalVel += horizontalAccel;
        verticalVel += verticalAccel;

        Vector2 velocities = new Vector2(horizontalVel * runSpeed, verticalVel * runSpeed);

        if (velocities.magnitude > maxSpeed) {
            velocities = velocities.normalized * maxSpeed;
            horizontalVel = velocities.x;
            verticalVel = velocities.y;
        }

        body.velocity = velocities;

        if (body.velocity != Vector2.zero) {
            float angle = Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            spaceReset = true;
        }
        blueness = Mathf.Max(0, blueness - .01f);

        float notBlue = 1 - blueness;
        spriteRenderer.color = new Color(notBlue, 1, notBlue);
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient( new Color(1, 0, 1, .5f) );

        if (Input.GetKeyDown(KeyCode.Space) && spaceReset) {
            spaceReset = false;
            if (energy > 0 && blueness == 0) {
                blueness = 1f;
                spriteRenderer.color = Color.blue;
                body.velocity = body.velocity.normalized * maxSpeed * 10f;
                energy--; 
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "spaceship_green")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.name == "Energy") {
            energy += 10;
            Destroy(collision.gameObject);
        }
    }
}
