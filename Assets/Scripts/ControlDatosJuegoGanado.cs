using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlDatosJuegoGanado : MonoBehaviour {

    public TextMeshProUGUI puntuacionTxt;
    private ControlDatosJuego datosJuego;

    private void Start() {

        datosJuego = GameObject.Find("DatosJuego").GetComponent<ControlDatosJuego>();
        SetPuntuacion(datosJuego.Puntuacion);
    }
    public void SetPuntuacion(int puntos) {
        puntuacionTxt.text = "¡Felicidades! \n ¡Has recolectado " + puntos + " naranjas!";
    }
}
