using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    public float Tiempo_hasta_explosion;
    public float radio_explosion;
    public float dano_explosion;
    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tiempo_hasta_explosion -= Time.deltaTime;
        if(Tiempo_hasta_explosion <= 0){
            explosion();
        }
    }

    void explosion(){
        if(Explosion != null){
            Instantiate(Explosion, transform.position, transform.rotation);

            Destroy(gameObject);

            Collider[] todosLosEnemigos = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), radio_explosion);
            foreach(Collider enemigo in todosLosEnemigos){
                if(!enemigo.gameObject.CompareTag("Jugador")){
                    enemigo.SendMessage("ataque_recibido",dano_explosion, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
