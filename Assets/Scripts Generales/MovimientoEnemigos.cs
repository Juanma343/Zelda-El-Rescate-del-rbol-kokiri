using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovimientoEnemigos : MonoBehaviour
{   
    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;

    public float cd;
    float distancia_ataque;
    bool bloqueado = false;
    bool atacando = false;
    int contador = 0;


    public float distancia_localizacion;
    Vector3 giro = new Vector3(0, 0, 0);
    private Animator animacion;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Jugador").transform;
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animacion = GetComponent<Animator>();
        distancia_ataque = pathfinder.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
    
        if(!bloqueado){
            if(Vector3.Distance(transform.position, target.transform.position) < distancia_localizacion){
                animacion.SetBool("es_visible",true);
                animacion.SetBool("bloqueo",false);


                if(Vector3.Distance(transform.position, target.transform.position) < distancia_ataque){
                    atacando = true;
                    animacion.SetBool("caminar",false);
                    animacion.SetBool("atacar",true);

                }else{
                    // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(giro_andar.x, giro_andar.y, giro_andar.z), Time.deltaTime * 1);
                    if(!atacando){
                        // contador++;
                        // Debug.Log("caminar" + contador);
                        // Debug.Log("hola2" + target. transform.position);
                        var lookPos = target.transform.position - transform.position;
                        lookPos.y = 0;
                        var rotation = Quaternion.LookRotation(lookPos);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * 100);
                        pathfinder.SetDestination(target.position);
                        animacion.SetBool("atacar",false);
                        animacion.SetBool("caminar",true);
                        animacion.SetFloat("multiplicador",pathfinder.velocity.magnitude);
                    }
                }
            }
        }
        else{
            // Debug.Log("bloqueado"); 
            animacion.SetBool("bloqueo",true);
            animacion.SetBool("es_visible",true);
            animacion.SetBool("caminar",false);
            animacion.SetBool("atacar",false);
        }
    }


    IEnumerator bloqueo_escudo_tiempo(){
        bloqueado = true;
        Debug.Log("hola Bloqueo");
        yield return new WaitForSeconds(Time.deltaTime * cd);
        Debug.Log("adios Bloqueo");
        bloqueado = false;
    }
    public void bloqueo_escudo(){
        StartCoroutine(bloqueo_escudo_tiempo());
    }

    public void terminaAtaque(){
        Debug.Log("termina ataque");
        atacando = false;
    }
}



