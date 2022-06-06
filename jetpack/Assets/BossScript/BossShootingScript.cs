using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootingScript : MonoBehaviour
{
    private float angle = 0f;
    private Vector2 bulletDirection;
    public float ShootRepeat = 0.5f;
    public bool isRight = true;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, ShootRepeat);
    }

    // Update is called once per frame
    public void Fire()
    {
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bullet = BulletPool.bulletPoolInstanse.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<BossBullet>().SetMoveDirection(bulDir);
        }

        if (isRight == true)
        {
            angle += 10f;
        }

        if (isRight == false)
        {
            angle -= 10f;
        }

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
