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
    public Transform gunHolder;
    bool facingLeft = false;
    public SpriteRenderer gunSprite;

    public Transform playerSprite;

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

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (worldPosition.x < transform.position.x && facingLeft)
        {
            Flip(); 
        }
        else if (worldPosition.x > transform.position.x && !facingLeft)
        {
            Flip();
        }

        movement = new Vector2(speed * inputX * Time.deltaTime, inputY);
        rb.AddForce(movement);

        //gun stuff

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(gun.transform.position);
        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        gun.transform.position = gunHolder.position;

        //Ta Daaa
        if (facingLeft)
        {
            gun.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle+180));
        }
        else gun.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle+180));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void Flip()
    {
        if (facingLeft)
        {
            gunSprite.flipY = true;
        }
        else
        {
            gunSprite.flipY = false;
        }
        facingLeft = !facingLeft;
        //playerSprite.localScale = new Vector3(-playerSprite.localScale.x, playerSprite.localScale.y, playerSprite.localScale.z);
        gunHolder.localPosition = new Vector3(gunHolder.localPosition.x * -1, gunHolder.localPosition.y, gunHolder.localPosition.z);
    }
}
