using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    public float velAbierto;
    public float velCerrado;
    public float estadoInicial;
    public float estadoActual;
    public Transform visual;
    void Start()
    {
        estadoActual = estadoInicial;
    }

    // Update is called once per frame
    void Update()
    {
        estadoActual -= (CambiarModo.singleton.abierto ? velAbierto : velCerrado) * Time.deltaTime;
        visual.localScale = new Vector3(1, estadoActual / estadoInicial, 1);
		if (estadoActual<=0)
		{
            SceneManager.LoadScene("GameOver");
		}
    }
}
