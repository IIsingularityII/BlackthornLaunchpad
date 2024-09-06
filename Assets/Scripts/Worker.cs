using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.ResourceFeature;

public class Worker : MonoBehaviour
{
    public LayerMask ResourceLayer;
    public float CollectDistance;
    public float TimeBetweenCollect;
    public int CollectAmount;
    private Resource _currentResource;
    private ResourcesFeature _resourcesFeature; 
    private float _nextCollectTime;
    private bool _isSelected;

    void Start()
    {
        
    }

    void Update()
    {
        if(_isSelected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
        else
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, CollectDistance, ResourceLayer);
            if (col != null && _currentResource == null)
            {
                _currentResource = col.GetComponent<Resource>();
            }
            else _currentResource = null;

            if(_currentResource != null)
            {
                if(Time.time > _nextCollectTime)
                {
                    _nextCollectTime = Time.time + TimeBetweenCollect;
                    _currentResource.Amount -= CollectAmount;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        _isSelected = true;
    }

    private void OnMouseUp()
    {
        _isSelected = false; 
    }
}
