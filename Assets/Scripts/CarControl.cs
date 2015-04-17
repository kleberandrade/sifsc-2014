using UnityEngine;
using System.Collections;

public class CarControl : MonoBehaviour
{
    public Transform centerMass;

    public WheelCollider wheelL;
    public WheelCollider wheelR;

    public Transform objWheelL;
    public Transform objWheelR;

    public float maxTorque;
    public float brake;
    public float friction;

    private float torqueL;
    private float torqueR;

    void Start()
    {
        //altera centro de massa
        rigidbody.centerOfMass = centerMass.localPosition; 
    }

    void FixedUpdate()
    {
        // armazena input do jogador
        torqueL = maxTorque * Input.GetAxis("Vertical");
        torqueR = maxTorque * Input.GetAxis("Vertical2");
        
        // aplica rotação das rodas de acordo com a velocidade do carro
        objWheelL.Rotate(0, 0, wheelL.rpm / 60 * 360 * Time.deltaTime);
        objWheelR.Rotate(0, 0, wheelR.rpm / 60 * 360 * Time.deltaTime);  

        // aplica o torque nas rodas
        wheelL.motorTorque = maxTorque * torqueL;
        wheelR.motorTorque = maxTorque * torqueR;


        // desacelera naturalmente
        if (torqueL == 0.0f && torqueR == 0.0f)
        {
            wheelL.motorTorque = 0;
            wheelR.motorTorque = 0;            

            wheelL.brakeTorque = friction;
            wheelR.brakeTorque = friction;
            print("desacelerando");
        }

        // frea
        if (Input.GetKey(KeyCode.Space))
        {
            wheelL.brakeTorque = brake;
            wheelR.brakeTorque = brake;
            print("freando");
        }
    }
}
