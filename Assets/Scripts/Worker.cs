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
    private ResourceBehaviour _currentResource;
    private ResourceFeatureOnScene _feature;
    private float _nextCollectTime;
    private bool _isSelected;
    private GameObject _altar;
    void Start()
    {
        _altar = GameObject.FindGameObjectWithTag("Altar");
        _feature = FindObjectOfType<ResourceFeatureOnScene>();
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
            if(Vector3.Distance(transform.position, _altar.transform.position) <= 0.5f)
            {
                _feature.AddSacrificedWorker();
                Destroy(gameObject);
            }
            Collider2D col = Physics2D.OverlapCircle(transform.position, CollectDistance, ResourceLayer);
            if (col != null && _currentResource == null)
            {
                _currentResource = col.GetComponent<ResourceBehaviour>();
            }
            else _currentResource = null;

            if(_currentResource != null)
            {
                if(Time.time > _nextCollectTime)
                {
                    _nextCollectTime = Time.time + TimeBetweenCollect;
                    _currentResource.CollectResource(CollectAmount);
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
