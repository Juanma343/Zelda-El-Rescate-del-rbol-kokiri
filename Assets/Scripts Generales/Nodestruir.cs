using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nodestruir : MonoBehaviour
{

    private void Awake()
    {
        var objetos = FindObjectsOfType<Nodestruir>();
        Debug.Log(objetos.Length);
        if (objetos.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
}
