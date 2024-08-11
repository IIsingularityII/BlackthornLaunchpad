using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    private bool isSelected;
    void Start()
    {
        
    }

    void Update()
    {
        if (isSelected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }
    private void OnMouseDown()
    {
        isSelected = true;
    }
    private void OnMouseUp()
    {
        isSelected = false; 
    }
}
