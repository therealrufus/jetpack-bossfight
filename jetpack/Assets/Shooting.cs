using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{public AudioSource shotSound;
    public GameObject bullet;
    public GameObject gun;
    public GameObject gunHolder;
    public GameObject flash;
 
    void Start()
    {
        flash.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
shotSound.Play();
            flash.gameObject.SetActive(true);
            Invoke("muzzleFlash", 0.1f);            
            GameObject.Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }        
    }

    void muzzleFlash()
    {
        flash.gameObject.SetActive(false);
    }
}
