using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startHit = 0;
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
}
