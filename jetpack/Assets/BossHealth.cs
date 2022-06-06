using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public SpriteRenderer whiteFlash;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        whiteFlash.color = new Color(1f, 1f, 1f, 0f);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TakeDamage(10);            
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        strobe();
        Invoke("unstrobe", 0.1f);        
    }

    void strobe()
    {
        whiteFlash.color = new Color(1f, 1f, 1f, .2f);
    }

    void unstrobe()
    {
        whiteFlash.color = new Color(1f, 1f, 1f, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            TakeDamage(10);
        }

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {

        TakeDamage(10);

    }
}
