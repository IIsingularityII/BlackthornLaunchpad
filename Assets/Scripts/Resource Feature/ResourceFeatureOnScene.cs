using System.Collections;
using UnityEngine;

namespace Scripts.ResourceFeature
{
    public class ResourceFeatureOnScene : MonoBehaviour
    {
        private ResourcesFeature _resourceFeature;

        void Start()
        {
            var resourceWood = new Resource(ResourceType.Wood, 0);
            var resourceCrystall = new Resource(ResourceType.Crystal, 0);
            var resourceBlood = new Resource(ResourceType.Blood, 0);
            var resources = new[] { resourceWood, resourceCrystall, resourceBlood };

            _resourceFeature = new ResourcesFeature(resources);
            _resourceFeature.ResourceChanged += OnResourceChanged;
        }

        void Update()
        {

        }

        private void OnDestroy()
        {
            _resourceFeature.ResourceChanged -= OnResourceChanged;
        }
        private void OnResourceChanged(ResourceType resourceType, int oldValue, int newValue)
        {
            Debug.Log($"Resource amount changed. Resource type: {resourceType}. OldValue: {oldValue}. NewValue: {newValue}");
        }
        
        public void AddResource(ResourceType type, int amount)
        {
            _resourceFeature.AddResource(type, amount);
        }
    }
}