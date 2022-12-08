using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour {
    public Animator animator;
    public AudioSource audioWin;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            Instantiate(audioWin);
            GetComponent<Animator>().enabled = true;
            Invoke("SiguienteNivel", 3f);
        }
    }

    public void SiguienteNivel() {
        SceneManager.LoadScene("EscenaFin");
    }
}
