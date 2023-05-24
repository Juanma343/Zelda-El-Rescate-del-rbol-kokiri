using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Entra Curar " + other.gameObject.name);
        if(other.gameObject.CompareTag("Jugador")){
            Debug.Log("Entra IF Curar");
            other.SendMessage("salud_aumentada",5, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
