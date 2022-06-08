using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int startHealth = 0;

    public Image[] hearts;

    private void Start()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = false;
        }
    }

    public void TakeDamage()
    {
        if (startHealth >= 5)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].enabled = false;
            }
            startHealth = 0;
        }

        Debug.Log("Player took damage!");
        hearts[startHealth].enabled = true;
        startHealth++;
    }
}
