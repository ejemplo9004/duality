using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarAcierto : MonoBehaviour
{
    public MovimientoMecanica[] positionFaces;
    public string puzzleAnswer,realAnswer;
    public static DetectarAcierto singleton;
	// Start is called before the first frame update
	private void Awake()
	{
        singleton = this;
	}
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
      
    }
    public void CheckAnswer(){
        puzzleAnswer = "";
        for (int i = 0; i < positionFaces.Length; i++)
        {
            puzzleAnswer += positionFaces[i].indexPosition.ToString();
         
        }
       if(puzzleAnswer == realAnswer) EsCorrecto();

    }
    private string EsCorrecto() {
        Application.Quit();
        return "es correcto";
    }
}
