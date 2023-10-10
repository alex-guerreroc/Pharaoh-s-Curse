using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorPuerta : MonoBehaviour
{
    // Start is called before the first frame update
    public bool puertaactiva=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag=="Puerta" && Input.GetKeyDown(KeyCode.E)){
            puertaactiva=!puertaactiva;
            other.transform.GetChild(0).gameObject.SetActive(puertaactiva);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag=="Puerta"){
            puertaactiva=true;
            other.transform.GetChild(0).gameObject.SetActive(puertaactiva);
        }
    }
}
