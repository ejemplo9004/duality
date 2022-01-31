using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Botones : MonoBehaviour
{
    public GameObject BotonPrefab;
    public int columnas, filas;
    public float espacioX, espacioY;
    [SerializeField] public int[] botonesCorrectos;
    
    private bool[] estadoDeBoton;
    private int preguntacorrecta = 0;
    
    private bool preguntaanterior = true;
    private int totalBotones;
    private int contador = 0;

    
    void Start()
    {
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                BotonPrefab.name = ("Boton " + (contador));
                var newBoton = Instantiate(BotonPrefab, new Vector3(espacioX * j, -espacioY * i), Quaternion.identity);
                newBoton.transform.parent = this.gameObject.transform;
                contador++;
            }
        }
        totalBotones = columnas*filas;


        //for(int i=0; i<columnas * filas; i++)
        //{
        //    BotonPrefab.name = ("Boton " + (i));
        //   var newBoton = Instantiate(BotonPrefab, new Vector3(espacioX * (i %columnas), espacioY * (i % filas)), Quaternion.identity);
        //    newBoton.transform.parent = this.gameObject.transform;
        //    totalBotones = i;
        //}
        totalBotones = totalBotones + 1;

        System.Array.Resize(ref estadoDeBoton, totalBotones);

        for (int i = 0; i < totalBotones; i++)
        {
            estadoDeBoton[i] = false;
        }

    }

    public void EstadoBotones(int boton, bool estado)
    {
        estadoDeBoton[boton] = estado;
        preguntacorrecta = 0;
        
       // Debug.Log("Boton " + boton + " estado = " + estado);

        for (int i = 0; i < totalBotones; i++)
        {
            if (estadoDeBoton[i] == true)
                preguntacorrecta--;

            for (int j = 0; j < botonesCorrectos.Length; j++)
            {
                if (i == botonesCorrectos[j] && estadoDeBoton[i] == true)
                {
                    preguntacorrecta++;
                    preguntaanterior = true;
                }
                if (i == botonesCorrectos[j] && estadoDeBoton[i] == false)
                {
                    preguntaanterior = false;
                    preguntacorrecta--;
                }
            }
        }
        Debug.Log("cuenta = " + preguntacorrecta);
        if (preguntacorrecta == 0)
        {
            Debug.Log("CORRECTO");
            //estadoDeBoton[i] == true &&
        }
        else
        {
            Debug.Log("INCORRECTO");
            
        }

    }
}
