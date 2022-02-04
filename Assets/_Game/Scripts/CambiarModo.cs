using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
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

    public UnityEvent eventoAbreCasco;
    public UnityEvent eventoCierraCasco;

	private void Awake()
	{
        singleton = this;
	}

	private void Start()
	{
		if (volumen == null)
		{
			volumen = GameObject.FindObjectOfType<Volume>();
		}
	}

	public void Cambiar()
	{
        abierto = !abierto;
        animCasco.SetBool("cerrado", !abierto);
		if (abierto)
		{
            eventoAbreCasco.Invoke();
		}
		else
		{
            eventoCierraCasco.Invoke();
		}
        Invoke("CambioColor", 0.5f);
	}

    void CambioColor()
	{
        volumen.profile = ((abierto) ? noDalto : siDalto);
	}
}
