using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int _woodAmount;
    private int _crystalAmount;
    private int _bloodAmount;
    [SerializeField] private Dictionary<string, int> _resources;
    void Start()
    {
        _resources = new Dictionary<string, int>();
    }

    void Update()
    {
        
    }
    
    public void AddResource(string resourceType, int amount)
    {

    }
}
