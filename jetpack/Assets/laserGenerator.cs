using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserGenerator : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("Animation playing");
            animator.SetTrigger("Trigger");
        }
    }
}
