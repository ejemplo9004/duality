using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCamino : MonoBehaviour
{
    public string answer = "adefc";
    public static PuzzleCamino singleton;
    public string acumulador = "";
    public delegate void Cubos();
    public Cubos cubos;
    // Start is called before the first frame update
    void Awake()
    {
        singleton = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool AddLetter(string letter)
    {
        acumulador += letter;
        return verificarPalabra();
    }

    public bool verificarPalabra()
    {
        if (acumulador.Length < 2)
        {
            return true;
        }
        if (!acumulador.Equals(answer.Substring(0, Mathf.Clamp(acumulador.Length, 1, answer.Length))))
        {
            Reiniciar();
            return false;
        }
        else
        {
            if (answer.Equals(acumulador))
            {
                Debug.Log("gano");
            }
        }
        return true;
    }

    public void Reiniciar()
    {
        cubos();
        acumulador = "";

    }
}
