using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
     private ColorTag colorTag;
    
    void Start()
    {
        colorTag = GetComponent<ColorTag>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter2D(Collider2D  other) {
        
    
       if(colorTag.color != other.gameObject.GetComponent<ColorTag>().color) return;
       Destroy(other.gameObject,0.8f);

    }
}
