using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redship : MonoBehaviour
{
    public float runSpeed;

    public Rigidbody2D body;

    float horizontalAccel = 0;
    float verticalAccel = 0;
    float horizontalVel = 0;
    float verticalVel = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAccel = Input.GetAxis("Horizontal");
        verticalAccel = Input.GetAxis("Vertical");

        horizontalVel += horizontalAccel;
        verticalVel += verticalAccel;

        float newAngle = Mathf.Atan(verticalVel / (horizontalVel + .01f)) / Mathf.PI * 180 + 270f;
 	
        transform.rotation = Quaternion.Euler(0, 0, newAngle);
        
        // TODO cap the player's movement, so that the magnitude of velocity going
        // diagonally is no faster than going in a direction
        body.velocity = new Vector2(horizontalVel * runSpeed, verticalVel * runSpeed);
    }
}
