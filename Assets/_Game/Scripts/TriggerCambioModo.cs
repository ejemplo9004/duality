using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOHNE.Accessibility.Colorblindness
{
    public class TriggerCambioModo : MonoBehaviour
    {
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				CambiarModo.singleton.Cambiar();
			}
		}
	}
}