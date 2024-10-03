using Scripts.ResourceFeature;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Scripts.ResourceFeature
{
    public class ResourceBehaviour : MonoBehaviour
    {
        public ResourceType Type;
        public Resource resource;
        [SerializeField] private int DefaultAmount;
        private int _currentAmount;
        [Inject] private ResourceFeatureOnScene _feature;

        void Start()
        {
            resource = new Resource(Type, DefaultAmount);
            _currentAmount = resource.Amount;
        }

        void Update()
        {
            if(_currentAmount <= 0) Destroy(gameObject);
        }
        
        public void CollectResource(int collectAmount)
        {
            var totalAmount = Mathf.Min(collectAmount, _currentAmount);
            _feature.AddResource(Type, totalAmount);
            _currentAmount -= collectAmount;
        }
    }
}