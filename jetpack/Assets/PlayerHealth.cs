using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startHit = 0;
    public SpriteRenderer whiteFlash;
    public AudioSource hitsound;
    public Image[] hearts;

    private void Start()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }
    }

    public void TakeDamage(bool isTakeDamage)
    {
        strobe();
        Invoke("unstrobe", 0.1f);

        if (isTakeDamage)
        {
            if (startHit < 5)
            {
                hearts[startHit].enabled = true;
                startHit++;
            }
            else
            {
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
        else
        {
            if (startHit >= 0 && hearts[0].enabled)
            {
                hearts[startHit - 1].enabled = false;
                startHit--;
            }
        }
    }

    void strobe()
    {
        whiteFlash.color = new Color(1f, 1f, 1f, .2f);
    }

    void unstrobe()
    {
        whiteFlash.color = new Color(1f, 1f, 1f, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            hitsound.Play();
        }
    }
}
