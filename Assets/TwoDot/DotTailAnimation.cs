using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DotTailAnimation : MonoBehaviour
{
   
   [SerializeField] private AnimationCurve curve;
   [SerializeField] private float offset;
   [SerializeField] private float lineGap= 1;
   [SerializeField] private float height= 0.1f;


   private Vector3[] LinePoints;
   private LineRenderer line;
   private int lineLength;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();

        lineLength = line.positionCount;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 1; i < lineLength; i++)
        {
            line.SetPosition(i,new Vector3(-i*lineGap,-curve.Evaluate((Time.time+ offset * i)) * height ,0));
        }
    }
}
