using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoCaixa : MonoBehaviour
{
    public float velocidade = 10;
    Rigidbody2D rigid;
    public float pular = 100;

    public float agachado = 2;
    public float correr = 9;
    bool chao;
    public LayerMask chaoLayer;
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
		rigid.velocity = (new Vector2(moveX * velocidade, rigid.velocity.y));

        
		if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            rigid.AddForce (new Vector2(0, pular));
        }
        if (Input.GetKey(KeyCode.DownArrow) && chao)
        {
            rigid.velocity = new Vector2(moveX * agachado, rigid.velocity.y);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            rigid.velocity = new Vector2(moveX * correr, rigid.velocity.y);
        }

        if (moveX < 0) 
		{
			spriteRenderer.flipX = true;
		}
		else if (moveX > 0)
		{
			spriteRenderer.flipX = false;
		}
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, chaoLayer);
        Debug.DrawRay(transform.position, -Vector2.up, Color.red);
        if (hit.collider != null)
        {
            chao = true;
        }
        else
        {
            chao = false;
        }
    }
}

