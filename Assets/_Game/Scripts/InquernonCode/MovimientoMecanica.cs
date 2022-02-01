using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMecanica : MonoBehaviour
{
    public bool esRueda = false;
    public int numFaces, indexPosition, multiplicador=1;
    public float anguloInicial, anguloEntrada;
    public Transform mirarMano, proyectado, rotado, laBolita, hijo;

    // Start is called before the first frame update
    void Start()
    {
        //hijo.parent = null;
      /*  mirarMano = new GameObject().transform;
        mirarMano.parent = transform.parent;
        mirarMano.position = transform.position;
        laBolita = new GameObject().transform;
        laBolita.parent = mirarMano;
        laBolita.position = mirarMano.position + mirarMano.forward;

        proyectado = new GameObject().transform;
        proyectado.parent = transform.parent;
        proyectado.position = transform.position;*/

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !esRueda)
        {
            indexPosition = (indexPosition + 1) % numFaces;
            transform.localEulerAngles = Vector3.right * indexPosition * (360f / (float)numFaces);
            anguloInicial = transform.localEulerAngles.x;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && esRueda)
        {
            mirarMano.LookAt(other.transform);
            proyectado.position = new Vector3(laBolita.position.x, laBolita.position.y, proyectado.position.z);
            transform.localEulerAngles = new Vector3(anguloInicial+
                ((Mathf.Sign(proyectado.position.x - transform.position.x)<0)?180:0)+
                (Mathf.Sign(proyectado.position.x - transform.position.x))*(Mathf.Asin((proyectado.position.y - transform.position.y)/(proyectado.position - transform.position).magnitude)*Mathf.Rad2Deg),  0, 0);

            //hijo.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DetectarAcierto.singleton.CheckAnswer();
            //hijo.parent = null;
        }
    }
    private void CalculateAngle()
    {
      /*  movDistance = finalPos - initialPos;
        angularMov = movDistance * (signo* scalarK);
        snapVar = 360 / numFaces;*/

    }
}