using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstanse;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughtBulletsInPool = true;

    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstanse = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughtBulletsInPool)
        {
            GameObject bullet = Instantiate(pooledBullet);
            bullet.SetActive(false);
            bullets.Add(bullet);
            return bullet;
        }

        return null;
    } 
}
