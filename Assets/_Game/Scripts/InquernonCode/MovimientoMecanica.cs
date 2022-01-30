using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMecanica : MonoBehaviour
{
    private float initialPos, finalPos, movDistance, angularMov, snapVar, alpha;
    public int numFaces, scalarK, indexPosition, signo;
    private Vector3 initialAngle, angle;

    // Start is called before the first frame update
    void Start()
    {
        initialAngle = this.transform.localEulerAngles;
        angle = initialAngle;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            initialPos = other.transform.position.y;
            signo = Mathf.RoundToInt(Mathf.Sign(transform.position.x - other.transform.position.x));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            finalPos = other.transform.position.y;
            CalculateAngle();
            alpha = initialAngle.x + angularMov;
            angle = new Vector3((alpha), initialAngle.y, initialAngle.z);
            this.transform.localEulerAngles = angle;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.transform.localEulerAngles = new Vector3(((Mathf.Round(alpha / snapVar) * snapVar)), initialAngle.y, initialAngle.z);
            initialAngle = this.transform.localEulerAngles;
            scalarK = signo*scalarK;
            indexPosition = Mathf.Abs(numFaces + (int)Mathf.Round(alpha / snapVar)) % numFaces;
        }
    }
    private void CalculateAngle()
    {
        movDistance = finalPos - initialPos;
        angularMov = movDistance * (signo* scalarK);
        snapVar = 360 / numFaces;

    }
}