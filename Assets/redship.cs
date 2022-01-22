using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redship : MonoBehaviour
{
    public float runSpeed = 20.0f;

    Rigidbody2D body;

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
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
