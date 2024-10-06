using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject blood;
    [SerializeField] private float speed;
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private float minDistance = 0.5f;
    private Vector3 _currentTarget;
    private Animator _camAnimator;
    

    void Start()
    {
        _camAnimator = Camera.main.GetComponent<Animator>();
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
        else if(collision.tag == "Trap")
        {
            _camAnimator.SetTrigger("shake");
            Destroy(collision.gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if(collision.GetComponent<Worker>() != null)
        {
            Instantiate(blood, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
