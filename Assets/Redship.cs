using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redship : MonoBehaviour
{
    public float runSpeed;

    public Rigidbody2D body;

    float horizontal = 0;
    float vertical = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // TODO give the player some momentum
        // TODO cap the player's movement, so that the magnitude of velocity going
        // diagonally is no faster than going in a direction
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
