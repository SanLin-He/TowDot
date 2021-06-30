using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float point;
    private ColorTag colorTag;
    
    void Start()
    {
        colorTag = GetComponent<ColorTag>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
