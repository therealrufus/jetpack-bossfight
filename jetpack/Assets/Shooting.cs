using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gun;
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject.Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        }
    }
}
