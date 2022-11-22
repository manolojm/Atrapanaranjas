using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour{

    // Variables
    public int velocidad;
    private int fuerzaSalto;
    private Rigidbody2D jugador;
    private SpriteRenderer sprite;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        velocidad = 10;
        fuerzaSalto = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador.velocity.x > 0) {
            sprite.flipX = false;
        } else {
            if (jugador.velocity.x < 0) {
                sprite.flipX = true;
            }
        }
        AnimarJugador();
        
    }

    private void AnimarJugador() {
        if (!TocandoSuelo()) {
            animator.Play("ProtagonistaJump");
        } else {
            if (jugador.velocity.x > 1 || jugador.velocity.x < -1 && jugador.velocity.y == 0) {
                animator.Play("ProtagonistaRun");
            } else {
                if (jugador.velocity.x < 1 || jugador.velocity.x > -1 && jugador.velocity.y == 0) {
                    animator.Play("ProtagonistaIdle");
                }
            }
        }
    }

    private void FixedUpdate() {
        float entradaX = Input.GetAxis("Horizontal");
        jugador.velocity = new Vector2(entradaX * velocidad, jugador.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && TocandoSuelo()) {
            jugador.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private bool TocandoSuelo() {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return(toca.collider!= null);
    }
}
