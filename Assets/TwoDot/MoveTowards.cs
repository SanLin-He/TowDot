using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction = Vector3.forward;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction *speed * Time.deltaTime;
    }
}
