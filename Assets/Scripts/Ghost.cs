using Scripts.ResourceFeature;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ghost : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [Inject] private DiContainer _diContainer;
    [Inject] private DiContainer container;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        if(Input.GetMouseButtonDown(0))
        {
            //container.InstantiatePrefabForComponent<ResourceBehaviour>(objectToSpawn, transform.position, Quaternion.identity, null);
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            //_diContainer.InstantiatePrefab(objectToSpawn, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }
}
