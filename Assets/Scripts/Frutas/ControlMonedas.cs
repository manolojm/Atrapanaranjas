using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMonedas : MonoBehaviour {
    public int cantidad;
    public AudioSource audioMoneda;

    private void Start() {
        cantidad = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Instantiate(audioMoneda);
            collision.gameObject.GetComponent<Jugador>().IncrementarPuntuacion(cantidad);
            //Destroy(gameObject);
            GetComponent<SpriteRenderer>().enabled = false;


            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
}
