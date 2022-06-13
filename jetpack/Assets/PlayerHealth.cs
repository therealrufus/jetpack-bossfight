using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startHit = 0;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public SpriteRenderer whiteFlash;
=======
public AudioSource hitsound;
>>>>>>> a10921f4d691c2ec8b28e7ff19fca8758c61615d
=======
public AudioSource hitsound;
>>>>>>> a10921f4d691c2ec8b28e7ff19fca8758c61615d
=======
public AudioSource hitsound;
>>>>>>> a10921f4d691c2ec8b28e7ff19fca8758c61615d
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        strobe();
        Invoke("unstrobe", 0.1f);
=======
        hitsound.Play();
>>>>>>> a10921f4d691c2ec8b28e7ff19fca8758c61615d
=======
        hitsound.Play();
>>>>>>> a10921f4d691c2ec8b28e7ff19fca8758c61615d
=======
        hitsound.Play();
>>>>>>> a10921f4d691c2ec8b28e7ff19fca8758c61615d
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
