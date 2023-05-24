using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extenderFinal : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject trigger;

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("puerta")){
            Debug.Log("puerta");
            trigger.transform.transform.Translate(0,0,5f);
        }
    }
}
