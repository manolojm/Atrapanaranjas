using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : MonoBehaviour
{
    public AudioSource audioMoneda;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Instantiate(audioMoneda);
            collision.gameObject.GetComponent<Jugador>().ActivarDobleSalto();
            Destroy(gameObject);
        }
    }
}
