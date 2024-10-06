using Scripts.ResourceFeature;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Ghost : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject buildEffect;
    [SerializeField] private GameObject spawnSound;
    [Inject] private DiContainer _diContainer;
    [Inject] private DiContainer container;
    private Animator _camAnimator;

    void Start()
    {
        _camAnimator = Camera.main.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(spawnSound);
            Instantiate(buildEffect, transform.position, Quaternion.identity);
            _camAnimator.SetTrigger("shake");
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
