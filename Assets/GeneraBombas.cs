using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneraBombas : MonoBehaviour
{
    public GameObject bomba;
    public GameObject localizacion;
    public GameObject actual;

    public void creaBomba()
    {
        if (actual == null)
        {
            actual = Instantiate(bomba, localizacion.transform.position, Quaternion.identity);
        }
    }
    public void eliminarBomba()
    {
        if (actual != null)
        {
            Destroy(actual);
        }
    }
}
