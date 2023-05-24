using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oscurecido : MonoBehaviour
{

    // Start is called before the first frame update
    public Image oscurecido1;
    public float velocidad;
    private float opacidadObjetivo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        blackout();
    }

    void blackout()
    {
        float currentopacity = oscurecido1.color.a;

        if(currentopacity < opacidadObjetivo)
        {
            oscurecido1.color = new Color(oscurecido1.color.r, oscurecido1.color.g, oscurecido1.color.b, currentopacity + velocidad * Time.deltaTime);
            if (oscurecido1.color.a >= opacidadObjetivo)
            {
                oscurecido1.color = new Color(oscurecido1.color.r, oscurecido1.color.g, oscurecido1.color.b, opacidadObjetivo);

            }
        }
        else if(currentopacity > opacidadObjetivo)
        {
            oscurecido1.color = new Color(oscurecido1.color.r, oscurecido1.color.g, oscurecido1.color.b, currentopacity - velocidad * Time.deltaTime);
            if (oscurecido1.color.a <= opacidadObjetivo)
            {
                oscurecido1.color = new Color(oscurecido1.color.r, oscurecido1.color.g, oscurecido1.color.b, opacidadObjetivo);

            }
        }
    }

    public void oscurecer()
    {
        opacidadObjetivo = 1;
    }

    public void aclarar()
    {
        opacidadObjetivo = 0;
    }

    public bool parar()
    {
        if (oscurecido1.color.a == opacidadObjetivo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
