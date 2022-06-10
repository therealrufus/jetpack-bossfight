using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startHit = 0;

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
