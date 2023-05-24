using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CorazonesJugador : MonoBehaviour
{
    public UnityEvent muerte;
    int corazon = 2, fragmento = 3;

    public void ataque_recibido(float fuerza)
    {
        Debug.Log("Recibido ataque de " + fuerza + " puntos de daño");
        while (fuerza > 0)
        {
            if (fragmento >= 0)
            {
                transform.GetChild(corazon).GetChild(fragmento).gameObject.SetActive(false);
                fragmento--;
                fuerza--;
            }
            else if (corazon >= 0)
            {
                corazon--;
                fragmento = 3;
                fuerza--;
            }
            else
            {
                Debug.Log("Muerto");
                fuerza = 0;
            }
        }
    }

    public void curar(float curacion)
    {
        Debug.Log("Curado " + curacion + " puntos de vida");
        while (curacion > 0)
        {
            if (fragmento < 3)
            {
                transform.GetChild(corazon).GetChild(fragmento).gameObject.SetActive(true);
                fragmento++;
                curacion--;
            }
            else if (corazon < 2)
            {
                corazon++;
                fragmento = 0;
                curacion--;
            }
            else
            {
                Debug.Log("Vida al máximo");
                curacion = 0;
            }
        }
    }
}
