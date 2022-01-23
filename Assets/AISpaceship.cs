using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpaceship : MonoBehaviour
{
    public GameObject target;
    public float maxSpeed;
    private float timeScale = 1f;
    private float accelRatio = 1f / 30f;
    Rigidbody2D body;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
    	body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
    	if (target == null) {
	    spriteRenderer.color = new Color(1f, 1f, 1f);
    	    return;
    	}
    	
	Vector2 diff = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
	float speed = timeScale;
	if (diff.magnitude < 5) {
	    spriteRenderer.color = new Color(1f, .7f, .7f);
	    // Could be fun to make it accelerate in current direction
	    // rather than still targeting the player
	    speed = speed * .5f;	    
	} else if (diff.magnitude < 1) {
	    spriteRenderer.color = new Color(1f, .5f, .5f);
	    return;
	} else {
	    spriteRenderer.color = new Color(1f, 1f, 1f);
	}
	Vector2 acceleration = new Vector2(diff.x * accelRatio * speed, diff.y * accelRatio * speed);
	body.velocity = body.velocity + acceleration;
	timeScale += .01f;
        if (body.velocity.magnitude > maxSpeed) {
            body.velocity = body.velocity.normalized * maxSpeed;
	}
    }
}
