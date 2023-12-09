using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpinner : MonoBehaviour
{
    [Header("Spin Force")]
    public float spinForceLeft = -350f;
    public float spinForceRight = 350f;

    [Header("Spin Direction")]
    public bool spinDirectionLeft;
    public bool spinDirectionRight;
    
    void FixedUpdate()
    {
        if (spinDirectionLeft)
            transform.Rotate(0, spinForceLeft * Time.fixedDeltaTime, 0);
        if (spinDirectionRight)
            transform.Rotate(0, spinForceRight * Time.fixedDeltaTime, 0);
    }
}
