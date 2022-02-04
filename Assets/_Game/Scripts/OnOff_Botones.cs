using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;

public class OnOff_Botones : MonoBehaviour
{
    public string tagCollision = "Player";
    public Material materialOn;
    public Material materialOff;
    public bool prendido = false;
    public UnityEvent eventoPresionar;

    private Renderer miRenderer;
    // Start is called before the first frame update
    void Start()
    {
        miRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(tagCollision))
        {
            if (!prendido)
            {
                miRenderer.material = materialOn;
                prendido = true;
            }
            else
            {
                miRenderer.material = materialOff;
                prendido = false;
            }
            PuzzlePatron.singleton.Revisar();
            eventoPresionar.Invoke();
        }
        
    }
}
