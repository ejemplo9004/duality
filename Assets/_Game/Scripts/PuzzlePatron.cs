using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePatron : MonoBehaviour
{
    public OnOff_Botones[] botones;
    public static PuzzlePatron singleton;
    public string patronReal    = "011010010";
    public string patronUsuario = "000000000";

    void Awake()
    {
        singleton = this;
    }

    public void Revisar()
	{
        string texto = "";
		for (int i = 0; i < botones.Length; i++)
		{
            texto += (botones[i].prendido)?"1":"0";
		}
        patronUsuario = texto;
		if (patronReal.Equals(patronUsuario))
		{
            print("Ganó");
		}
	}

}
