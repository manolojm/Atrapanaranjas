using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour{

    // Variables
    public int velocidad = 2;
    private int fuerzaSalto = 6;
    public int fuerzaSaltoDoble = 3;

    bool isJumping = false;
    bool saltarDeNuevo = false;

    private Rigidbody2D jugador;
    private SpriteRenderer sprite;
    private Animator animator;

    public int vidas;
    private bool vulnerable;

    public int tiempoNivel;
    private float tiempoInicio;
    private int tiempoEmpleado;

    public int puntuacion;
    public int numeroPowerUps;
    public Canvas canvas;
    private ControlHud hud;

    public PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        velocidad = 6;
        fuerzaSalto = 8;

        vulnerable = true;
        tiempoInicio = Time.time;
        puntuacion = 0;

        hud = canvas.GetComponent<ControlHud>();
        hud.SetPowerUps(numeroPowerUps);
        hud.SetVidas(vidas);
    }

    // Update is called once per frame
    void Update()
    {
        // Salto
        if (Input.GetKeyDown("space")) {
            if (!isJumping) {
                saltarDeNuevo = true;
                jugador.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                isJumping = true;
            } else {
                if (Input.GetKeyDown("space")) {
                    if (saltarDeNuevo) {
                        animator.SetBool("DoubleJump", true);
                        jugador.AddForce(Vector2.up * fuerzaSaltoDoble, ForceMode2D.Impulse);
                        isJumping = true;
                        saltarDeNuevo = false;
                    }
                }
            }
        } 

        // Animación salto
        if (isJumping) {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        } else {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }


        // Anumación caida
        if (jugador.velocity.y < 0) {
            animator.SetBool("Falling", true);
        } else {
            animator.SetBool("Falling", false);
        }


        tiempoEmpleado = (int)Time.time - (int)tiempoInicio;
        if (tiempoNivel - tiempoEmpleado < 0)
            //Perdido();
        if (numeroPowerUps == 0) {
            //Ganado();
        }
        hud.SetTiempo(tiempoEmpleado);
    }

    public void IncrementarPuntuacion(int puntos) {
        puntuacion += puntos;
        hud.SetPowerUps(puntuacion);
        //datosJuego.Puntuacion = datosJuego.Puntuacion + 5;
    }

    private void FixedUpdate() {

        // Movimiento derecha
        if (Input.GetKey("d") || Input.GetKey("right")) {
            jugador.velocity = new Vector2(velocidad, jugador.velocity.y);
            sprite.flipX = false;
            animator.SetBool("Run", true);

        } else {

            // Movimiento izquierda
            if (Input.GetKey("a") || Input.GetKey("left")) {
                jugador.velocity = new Vector2(-velocidad, jugador.velocity.y);
                sprite.flipX = true;
                animator.SetBool("Run", true);
            
             // Parado
            } else {
                jugador.velocity = new Vector2(0, jugador.velocity.y);
                animator.SetBool("Run", false);
            }
        }

       

    }

    private void OnCollisionEnter2D(Collision2D other) {
        //Si el jugador colisiona con un objeto con la etiqueta suelo
        if (other.gameObject.CompareTag("Suelo")) {
            //Digo que no está saltando (para que pueda volver a saltar)
            isJumping = false;
            //Le quito la fuerza de salto remanente que tuviera
            jugador.velocity = new Vector2(jugador.velocity.x, 0);
        }
    }

    private void HacerVulnerable() {
        vulnerable = true;
        sprite.color = Color.white;
    }

    public void QuitarVidas() {
        if (vulnerable) {
            vulnerable = false;
            if (vidas == 1) {
                //Perdido();
            }
            vidas--;
            hud.SetVidas(vidas);
            //audio.PlayOneShot(sonidoVida);
            sprite.color = new Color32(240, 152, 180, 255);
            Invoke("HacerVulnerable", 1f);
        }
    }
}
