using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gestion_dano_de_enemigo : MonoBehaviour
{
    public int dano_ataque = 5;
    public UnityEvent bloqueo_escudo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter (Collider other){
            Debug.Log("hola");
        if(other.gameObject.CompareTag("Jugador")){
            other.SendMessage("ataque_recibido",dano_ataque, SendMessageOptions.DontRequireReceiver);
        }
        else if(other.gameObject.CompareTag("escudo")){
            Debug.Log("Bloqueo con escudo");
            bloqueo_escudo.Invoke();
        }
    }

    IEnumerable WaitForSeconds(float tiempo){
        yield return new WaitForSeconds(tiempo);
    }

}
