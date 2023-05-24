using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestion_dano_de_jugador : MonoBehaviour
{
    public int dano_ataque = 5;


    void OnTriggerEnter(Collider other){
        if(!other.gameObject.CompareTag("Jugador")){
            other.SendMessage("ataque_recibido",dano_ataque, SendMessageOptions.DontRequireReceiver);
        }
    }
}
