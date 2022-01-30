using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCambioModo : MonoBehaviour
{
	public Animator animator;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			CambiarModo.singleton.Cambiar();
			animator.SetTrigger("boton");
		}
	}
}