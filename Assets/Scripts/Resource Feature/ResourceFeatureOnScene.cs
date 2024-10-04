using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.ResourceFeature
{
    public class ResourceFeatureOnScene : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI woodAmount;
        [SerializeField] private TextMeshProUGUI bloodAmount;
        [SerializeField] private TextMeshProUGUI crystalAmount;
        public ResourcesFeature resourceFeature;
        public TMP_Text sacrificeText;
        [SerializeField] private int numberOfWorkersSacrificed;
        [SerializeField] private int maxWorkersForSacrifice;


        void Start()
        {
            var resourceWood = new Resource(ResourceType.Wood, 0);
            var resourceCrystall = new Resource(ResourceType.Crystal, 0);
            var resourceBlood = new Resource(ResourceType.Blood, 0);
            var resources = new[] { resourceWood, resourceCrystall, resourceBlood };

            resourceFeature = new ResourcesFeature(resources);
            resourceFeature.ResourceChanged += OnResourceChanged;
        }

        void Update()
        {

        }

        private void OnDestroy()
        {
            resourceFeature.ResourceChanged -= OnResourceChanged;
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
            resourceFeature.AddResource(type, amount);
        }

        public void AddSacrificedWorker()
        {
            numberOfWorkersSacrificed++;
            sacrificeText.text = numberOfWorkersSacrificed + " / " + maxWorkersForSacrifice;
            if(numberOfWorkersSacrificed >= maxWorkersForSacrifice)
            {
                Debug.Log("Win");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } 
        }
    }
}