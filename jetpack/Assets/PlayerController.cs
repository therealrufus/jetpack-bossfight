using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jetSpeed;
    public int maxFuel;
    public int fuel;
    public float gravity = 10f;
    public GameObject gun;
    public GameObject jetpackFire;
    public Transform playerSprite;

    Vector2 movement = new Vector2();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jetpackFire.SetActive(false);

    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY;

        if (Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            jetpackFire.SetActive(true);
            fuel--;
            inputY = jetSpeed - gravity * Time.deltaTime;
        }
        else
        {
            jetpackFire.SetActive(false);
            inputY = -gravity * Time.deltaTime;
            if (fuel < maxFuel)
            {
                fuel++;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {            
            gun.transform.rotation = Quaternion.Euler(new Vector3(0, 00, -90));
            gun.transform.localPosition = new Vector3(0.512f, -0.111f, -2f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            gun.transform.rotation = Quaternion.Euler(new Vector3(0, 00, 90));
            gun.transform.localPosition = new Vector3(0.8f, -0.2f, -2f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gun.transform.rotation = Quaternion.Euler(new Vector3(0, 00, -180));
            gun.transform.localPosition = new Vector3(0.4f, -0.3f, -2f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            gun.transform.rotation = Quaternion.Euler(new Vector3(0, 00, 0));
            gun.transform.localPosition = new Vector3(0.5f, -0.2f, -2f);
        }

        movement = new Vector2(speed * inputX * Time.deltaTime, inputY);
        rb.AddForce(movement);
    }
}
