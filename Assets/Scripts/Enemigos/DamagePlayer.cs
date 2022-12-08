using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public Collider2D enemigo;
    public AudioSource audioVida;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Instantiate(audioVida);
            collision.gameObject.GetComponent<Jugador>().QuitarVidas();
        }
    }
}
