using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoFormiga : MonoBehaviour {
    public int velocidade = 1;
    public int velocidadeataca = 2;
    public int tempo1 = 1;
    public int tempo2 = 20;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    public LayerMask CaixaLeite;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        float moveX = velocidade;
        rigid.velocity = (new Vector2(moveX, rigid.velocity.y));
        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveX > 0)
        {
            spriteRenderer.flipX = false;
        }
        tempo1 = tempo1 + 1;
        if (tempo1 >= 30)
        {
            tempo1 = 1;
        }
        if (Divisivel(tempo1,tempo2))
        {
            rigid.velocity = (new Vector2(moveX*-1, rigid.velocity.y));
        }       
    }
    public void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 2, CaixaLeite);
        Debug.DrawRay(transform.position, Vector2.left, Color.red);
        if (hit.collider != null)
        {
			velocidade = -2;
        }
        else
        {
            velocidade = 1;
        }
    }
    public bool Divisivel(int tempo1, int tempo2)
    {
        return (tempo1 % tempo2) == 0;
    }
}