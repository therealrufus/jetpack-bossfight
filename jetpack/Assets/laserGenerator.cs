using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserGenerator : MonoBehaviour
{
    public Animator laserLeft;
    public Animator laserRight;
    public float startAnimation;
    private float targetTime;
    public AudioSource laserAudio;
    void Start()
    {
        targetTime = startAnimation;
    }

    private void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            PlayAnimation();
            targetTime = Random.Range(10, 21);
        }
    }

    void PlayAnimation()
    {
        double value = Random.value;
        laserAudio.Play();

        if (value >= 0.5)
        {
            laserLeft.SetTrigger("LaserLeft");
        }
        else if (value < 0.1)
        {
            laserRight.SetTrigger("LaserRight");
            laserLeft.SetTrigger("LaserLeft");
        }
        else
        {
            laserRight.SetTrigger("LaserRight");
        }
    }
}
