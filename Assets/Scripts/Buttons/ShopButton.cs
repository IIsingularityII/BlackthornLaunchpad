using Scripts.ResourceFeature;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private int woodCost;
    [SerializeField] private int crystalCost;
    [SerializeField] private int bloodCost;
    [Inject] private ResourceFeatureOnScene _feature;
    private Button _shopButton;
    void Start()
    {
        _shopButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_feature.resourceFeature.HasResource(ResourceType.Wood, woodCost) &&
            _feature.resourceFeature.HasResource(ResourceType.Crystal, crystalCost) &&
             _feature.resourceFeature.HasResource(ResourceType.Blood, bloodCost))
        {
            _shopButton.interactable = true;
        }
        else
        {
            _shopButton.interactable = false;
        }
    }
    public void RemoveResources()
    {
        _feature.resourceFeature.SpendResource(ResourceType.Wood, woodCost);
        _feature.resourceFeature.SpendResource(ResourceType.Crystal, crystalCost);
        _feature.resourceFeature.SpendResource(ResourceType.Blood, bloodCost);
    }
}
