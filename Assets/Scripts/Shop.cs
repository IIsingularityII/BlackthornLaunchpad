using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Ghost worker, tree, crystal, village, trap;
    private void Start()
    {
        
    }
    
    public void OnShopClicked(string category)
    {
        switch (category)
        {
            case "worker" :
                Instantiate(worker);
                break;
            case "tree":
                Instantiate(tree);
                break;
            case "crystal":
                Instantiate(crystal);
                break;
            case "village":
                Instantiate(village);
                break;
            case "trap":
                Instantiate(trap);
                break;
        }
    }
}

