using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorClave : MonoBehaviour
{
    public Material[] colors;
    public string val;
    // Start is called before the first frame update
    void Start()
    {
        Reiniciar();
        PuzzleCamino.singleton.cubos += Reiniciar;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PuzzleCamino.singleton.AddLetter(val))
            {
                this.GetComponent<Renderer>().material = colors[1];

            }
        }

    }

    private void Reiniciar()
    {
        this.GetComponent<Renderer>().material = colors[0];

    }
}
