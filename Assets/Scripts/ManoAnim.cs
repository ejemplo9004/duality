using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]
public class ManoAnim : MonoBehaviour
{
    public InputDeviceCharacteristics controlCaracteristicas;

    Animator animator;
    public InputDevice targetDevice;
    public GameObject[] objetosDesactivar;

    XRDirectInteractor interactor;
    void Start()
    {
        animator = GetComponent<Animator>();
        Inicializar();
        StartCoroutine(BuscarIntereactor());
    }

    public void Inicializar()
	{
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controlCaracteristicas, devices);
		if (devices.Count > 0)
		{
            targetDevice = devices[0];
		}
	}

    IEnumerator BuscarIntereactor()
	{
        do
        {
            yield return new WaitForSeconds(1);
            interactor = transform.GetComponentInParent<XRDirectInteractor>();
            if (interactor == null)
            {
                //Destroy(gameObject);
            }
            else
            {
                transform.localScale = Vector3.one;
                interactor.onSelectEntered.AddListener(DesactivarObjetos);
                interactor.onSelectExited.AddListener(ActivarObjetos);
            }
        } while (interactor == null);
    }

    public void ActivarObjetos (XRBaseInteractable p)
    {
        ACDC(true);
    }
    public void DesactivarObjetos(XRBaseInteractable p)
    {
        ACDC(false);
    }

    void ACDC(bool q)
	{
		for (int i = 0; i < objetosDesactivar.Length; i++)
		{
            objetosDesactivar[i].SetActive(q);
		}
	}

    void Update()
    {
		if (!targetDevice.isValid)
		{
            Inicializar();
		}
		else
		{

		    if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
		    {
                animator.SetFloat("Trigger", triggerValue);
		    }else
            {
                animator.SetFloat("Trigger", 0);
            }

            if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                animator.SetFloat("Grip", gripValue);
            }
            else
            {
                animator.SetFloat("Grip", 0);
            }
		}
    }
}
