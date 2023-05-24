using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gestion_vida_jugador : MonoBehaviour
{
    public int Vida = 5;
    public int MaxVida = 10;

    public int corazon, fragmento;

    public Canvas corazones;

    public UnityEvent muerte;

    void Start()
    {
        corazon = MaxVida / 4;
        fragmento = MaxVida % 4;
        int fuer = MaxVida - Vida;
        ataque_recibido(fuer);
    }

    void ataque_recibido(int fuerza){
        Debug.Log("Recibido ataque de " + fuerza + " puntos de daño");
        
        Vida -= fuerza;
        while (fuerza > 0)
        {
            if(corazon >= 0)
            {
                if (fragmento > 0)
                {
                    fragmento--;
                    fuerza--;
                }
                else if (fragmento <= 0)
                {
                    corazon--;
                    fragmento = 3;
                    fuerza--;
                }
                corazones.transform.GetChild(corazon).GetChild(fragmento+1).gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Muerto");
                fuerza = 0;
            }
        }
        if(Vida <= 0){
            Debug.Log("Muerto Evento");
            muerte.Invoke();
        }
    }
    public void salud_aumentada(int curacion){
        Debug.Log("Curado " + curacion + " puntos de vida");
        int corazon = Vida / 4;
        int fragmento = Vida % 4;
        Vida += curacion;
        if(Vida > MaxVida){
            Vida = MaxVida;
        }
        while (curacion > 0)
        {
            if(corazon < 3)
            {
                if (fragmento < 3)
                {
                    fragmento++;
                    curacion--;
                }
                else if (fragmento >= 3)
                {
                    corazon++;
                    fragmento = 0;
                    curacion--;
                }
                corazones.transform.GetChild(corazon).GetChild(fragmento+1).gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Vida al máximo");
                curacion = 0;
            }
        }
    }
}