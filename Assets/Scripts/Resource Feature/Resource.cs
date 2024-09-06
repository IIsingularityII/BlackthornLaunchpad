using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ResourceFeature
{
    public class Resource : MonoBehaviour, IResource
    {
        public event Action<int, int> Changed;
        public ResourceType Type { get; }
        public int Amount
        {
            get => _amount;
            set
            {
                var oldValue = _amount;
                _amount = value;
                if(oldValue != _amount)
                {
                    Changed?.Invoke(oldValue, _amount);
                }
            }
        }
        private int _amount;
        public Resource(ResourceType type, int amountByDefault = default)
        {
            Type = type;
            Amount = amountByDefault;
        }
        void Start()
        {

        }

        void Update()
        {
            if (Amount <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

