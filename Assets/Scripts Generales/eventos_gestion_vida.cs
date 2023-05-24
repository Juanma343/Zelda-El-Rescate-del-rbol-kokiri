using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventos_gestion_vida : MonoBehaviour
{
    float vida_restante;
    public Image barraVida;

    void Start(){
        vida_restante = GetComponent<gestion_vida>().Vida / GetComponent<gestion_vida>().MaxVida;
        barraVida.transform.localScale = new Vector3 (vida_restante,1,1);
    }

    //Evento que simboliza cuando se recibe daño
    public void dano_recibido(){
        vida_restante = (float) GetComponent<gestion_vida>().Vida / GetComponent<gestion_vida>().MaxVida;
        Debug.Log("Recibido ataque de " + vida_restante + " puntos de daño");
        barraVida.transform.localScale = new Vector3 (vida_restante,1,1);
    }

    //Evento que simboliza cuando muere
    public void muerte(){
        Destroy(gameObject);
    }
}
