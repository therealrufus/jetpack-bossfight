using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    private float moveSpeed = 10f;

    private BulletPool boss;
    private void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(true);
            Destroy();
        }
    }
}
