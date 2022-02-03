using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDeEscena : MonoBehaviour
{
    public string nombreEscena;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(nombreEscena); 
		}
	}
}
