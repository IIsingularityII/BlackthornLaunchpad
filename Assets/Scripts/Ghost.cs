using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ghost : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [Inject] private DiContainer _diContainer;

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
            //Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            _diContainer.InstantiatePrefab(objectToSpawn, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }
}
