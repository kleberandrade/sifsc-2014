using UnityEngine;
using System.Collections;

public class WheelAlignment : MonoBehaviour
{

    public WheelCollider wheelCollider;

    private RaycastHit hit;


    void FixedUpdate()
    {
        //posiçao do centro do wheelcollider 
        Vector3 centerCollider = wheelCollider.transform.position;

        //lança um raio a partir do centor do wcollider, para baixo, do tamanho do raio da roda mais a suspensao
        if (Physics.Raycast(centerCollider, -wheelCollider.transform.up, out hit, wheelCollider.suspensionDistance + wheelCollider.radius))
            //se tocar em algo comprime a roda para cima a partir do ponto de contato
            transform.position = hit.point + (wheelCollider.transform.up * wheelCollider.radius);
        else
            //senaoa suspensao extende a roda para baixo a partir do seu centro
            transform.position = centerCollider - (wheelCollider.transform.up * wheelCollider.suspensionDistance);
    }
}
