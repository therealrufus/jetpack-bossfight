using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startHit = 0;
    public SpriteRenderer whiteFlash;
    public AudioSource hitsound;
    public Image[] hearts;

    private void Start()
    {
        hitsound = GetComponent<AudioSource>();
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }
    }

    public void TakeDamage(bool isTakeDamage)
    {
        strobe();
        Invoke("unstrobe", 0.1f);
        hitsound.Play();

        if (startHit >= 5)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].enabled = false;
            }
            startHit = 0;
        }

        if (isTakeDamage)
        {
            hearts[startHit].enabled = true;
            startHit++;
        }
        else
        {
            if (startHit > 0)
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
        whiteFlash.color = new Color(1f, 1f, 1f, 0f);
    }
}
