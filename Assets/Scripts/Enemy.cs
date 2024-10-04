using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private float minDistance = 0.5f;
    private Vector3 _currentTarget;

    void Start()
    {
       SetRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, _currentTarget) > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
        }
        else
        {
            SetRandomTarget();
        }
    }

    private void SetRandomTarget()
    {
        _currentTarget = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Altar")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
