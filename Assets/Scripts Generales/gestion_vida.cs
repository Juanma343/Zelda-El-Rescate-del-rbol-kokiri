using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gestion_vida : MonoBehaviour
{
    public int Vida = 5;
    public int MaxVida = 10;

    public UnityEvent muerte;
    public UnityEvent dano_recibido;

    void ataque_recibido(int fuerza){
        Debug.Log("Recibido ataque de " + fuerza + " puntos de daño");
        Vida -= fuerza;
        dano_recibido.Invoke();
        if(Vida <= 0){
            muerte.Invoke();
        }
    }
}