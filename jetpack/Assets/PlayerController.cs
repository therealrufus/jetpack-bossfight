using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jetSpeed;
    public int maxFuel = 300;
    public int fuel = 300;
    public float gravity = 10f;

    Vector2 movement = new Vector2();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY;
        if (Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            fuel--;
            inputY = jetSpeed - gravity * Time.deltaTime;
        }
        else
        {
            inputY = -gravity*Time.deltaTime;
            if (fuel < maxFuel)
            {
                fuel++;
            }
        }
        movement = new Vector2(speed * inputX * Time.deltaTime, inputY);

        rb.AddForce(movement);
    }
}
