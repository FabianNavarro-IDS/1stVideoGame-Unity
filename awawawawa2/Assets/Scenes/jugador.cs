using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador : MonoBehaviour
{
    public float fuerzasalto;
    public gamemannager Gamemannager;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("EstaSaltando", true);
            rigidbody2D.AddForce(new Vector2(0, fuerzasalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            animator.SetBool("EstaSaltando", false);
        } 

        if (collision.gameObject.tag == "pedrolo")
        {
            Gamemannager.gameOver = true;
        }
    }
}
