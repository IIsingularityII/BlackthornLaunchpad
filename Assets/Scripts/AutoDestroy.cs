using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
