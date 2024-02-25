using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour
{
    private Vector3 characterPos;
    private Animator animator;
    void Start()
    {
        characterPos = FindObjectOfType<Player>().transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= characterPos.x)
        {
            characterPos = FindObjectOfType<Player>().transform.position;
            transform.localScale = new Vector3(1, 1, 1);
        } else
        {
            characterPos = FindObjectOfType<Player>().transform.position;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
