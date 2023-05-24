using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danno3 : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem onda_expansiva;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ondaExpansiva(){
        onda_expansiva.Play();
        Collider[] hitColliders = Physics.OverlapBox(transform.GetChild(6).position, new Vector3(0.8f,1,2));
        int i = 0;
        while (i < hitColliders.Length)
        {
            if(hitColliders[i].gameObject.CompareTag("Jugador")){
                hitColliders[i].gameObject.SendMessage("ataque_recibido",5, SendMessageOptions.DontRequireReceiver);
            }
            i++;
        }
    }
}
