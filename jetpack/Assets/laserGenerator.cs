using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserGenerator : MonoBehaviour
{
    private Animator animator;
    public float startAnimation;
    private float targetTime;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //InvokeRepeating("PlayAnimation", startAnimation, Random.Range(10,20));
        targetTime = 20;
    }

    private void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            PlayAnimation();
            targetTime = Random.Range(15, 36);
            //Debug.Log(targetTime);
        }
        Debug.Log(targetTime);
    }

    void PlayAnimation()
    {
        if (Random.value >= 0.5)
        {
            animator.SetTrigger("LaserLeft");
        }
        else
        {
            animator.SetTrigger("LaserRight");
        }
    }
}
