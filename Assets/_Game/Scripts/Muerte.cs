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

    public float actualNormalizado;


    void Start()
    {
        estadoActual = estadoInicial;
        Invoke("Revisar", 5);
    }

    public void Revisar()
	{
        GameObject g = GameObject.Find("eterno");
		if (g != null)
		{
            this.enabled = false;
		}
	}

    // Update is called once per frame
    void Update()
    {

        estadoActual -= (CambiarModo.singleton.abierto ? velAbierto : velCerrado) * Time.deltaTime;
        actualNormalizado = estadoActual / estadoInicial;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Vida", actualNormalizado);

        visual.localScale = new Vector3(1, estadoActual / estadoInicial, 1);
		if (estadoActual<=0)
		{
            SceneManager.LoadScene("GameOver");
		}
    }
}
