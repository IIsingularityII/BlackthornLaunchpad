using System.Collections;
using TMPro;
using UnityEngine;

namespace Scripts.ResourceFeature
{
    public class ResourceFeatureOnScene : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI woodAmount;
        [SerializeField] private TextMeshProUGUI bloodAmount;
        [SerializeField] private TextMeshProUGUI crystalAmount;
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
            switch (resourceType)
            {
                case ResourceType.Wood:
                    woodAmount.text = newValue.ToString();
                    break;
                case ResourceType.Blood:
                    bloodAmount.text = newValue.ToString();
                    break;
                case ResourceType.Crystal:
                    crystalAmount.text = newValue.ToString();
                    break;
            }
        }
        
        public void AddResource(ResourceType type, int amount)
        {
            _resourceFeature.AddResource(type, amount);
        }
    }
}