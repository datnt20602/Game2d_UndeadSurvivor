using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour
{
    private Vector3 characterPos;
    private Animator animator;
    void Start()
    {
        characterPos = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != characterPos)
        {
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0.001f);
        }
        if (transform.position.x <= characterPos.x)
        {
            characterPos = transform.position;
            transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            characterPos = transform.position;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
