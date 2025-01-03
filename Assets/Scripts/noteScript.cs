using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteScript : MonoBehaviour
{
    [Header ("Control Note Speed")]
    public float noteSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(-this.transform.forward * noteSpeed * Time.deltaTime);
    }
}
