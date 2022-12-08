using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour {
    public void OnJugar() {
        SceneManager.LoadScene("Escena1");
    }

    public void OnCreditos() {
        SceneManager.LoadScene("EscenaCreditos");
    }

    public void OnAyuda() {
        SceneManager.LoadScene("EscenaOpciones");
    }

    public void OnSalir() {
        Application.Quit();
    }

    public void OnMenu() {
        SceneManager.LoadScene("EscenaMenu");
    }
}
