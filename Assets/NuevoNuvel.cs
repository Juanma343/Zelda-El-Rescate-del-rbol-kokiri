using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NuevoNuvel : MonoBehaviour
{
    public UnityEvent parar;
    public UnityEvent empezar;
    private oscurecido pasar;
    private Vector3 posicionInicial1 = new Vector3(68.4400024f,8.90999985f,-19.0200005f);
    private Vector3 posicionInicial2 = new Vector3(2.74000001f,0.702882349f,3.6500001f);

     private Vector3 posicionInicial3 = new Vector3(2.74000001f,0.702882349f,3.6500001f);
    public GameObject player;

    bool pasarNivel = false;
    bool repeNivel = false;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        pasar = FindObjectOfType<oscurecido>();
        pasar.aclarar();
        empezar.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(pasarNivel && pasar.parar())
        {
            if(repeNivel == true)
            {
                
                Debug.Log("repetir");
                repeNivel = false;
                pasarNivel = false;
                int i = SceneManager.GetActiveScene().buildIndex;
                if (i == 0)
                {
                    player.transform.position = posicionInicial1;
                }
                else if (i == 1)
                {
                    player.transform.position = posicionInicial2;
                }
                else
                {
                    player.transform.position = posicionInicial3;
                }
            
                SceneManager.UnloadSceneAsync(i);
                SceneManager.LoadSceneAsync(i);
            }
            else{
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    player.transform.position = posicionInicial2;
                    SceneManager.LoadScene(1);
                }
                else if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    player.transform.position = posicionInicial3;
                    SceneManager.LoadScene(2);
                }
                else
                {
                    SceneManager.LoadScene(3);
                }
            }
            pasarNivel = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "FinNivel")
        {
            pasarNivel = true;
            pasar.oscurecer();
            parar.Invoke();
        }
        if(other.gameObject.tag == "InicioNivel")
        {
            transform.GetChild(3).GetComponent<gestion_vida_jugador>().salud_aumentada(transform.GetChild(3).GetComponent<gestion_vida_jugador>().MaxVida);
            pasar.aclarar();
            empezar.Invoke();
            Debug.Log("TerminaInicio");
        }
    }

    public void repNivel()
    {
        pasar.oscurecer();
        parar.Invoke();
        pasarNivel = true;
        repeNivel = true;
    }

    public void pasaNivel()
    {
        pasarNivel = true;
    }
}
