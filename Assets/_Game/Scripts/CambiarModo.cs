using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SOHNE.Accessibility.Colorblindness
{
    public class CambiarModo : MonoBehaviour
    {
        public Animator animCasco;
        public bool abierto;
        //public Colorblindness colorizacion;
        public Volume volumen;
        public VolumeProfile siDalto;
        public VolumeProfile noDalto;

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
            volumen.profile = ((abierto) ? noDalto : siDalto);
		}
    }
}
