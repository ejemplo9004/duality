using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SOHNE.Accessibility.Colorblindness
{
    public class CambiarModo : MonoBehaviour
    {
        public Animator animCasco;
        public bool abierto;
        public Colorblindness colorizacion;

        public int modoDaltonismo;
        public static CambiarModo singleton;

		private void Awake()
		{
            singleton = this;
		}
		public void Cambiar()
		{
            abierto = !abierto;
            animCasco.SetBool("cerrado", !abierto);
            Invoke("CambioColor", 0.5f);
		}

        void CambioColor()
		{
            colorizacion.Change((abierto) ? 0 : modoDaltonismo);
		}
    }
}
