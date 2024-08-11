using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string ResourceType;
    public int ResourceAmount;
    void Start()
    {
        
    }

    void Update()
    {
        if(ResourceAmount <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
