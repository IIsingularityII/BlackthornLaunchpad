using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.ResourceFeature
{
    public interface IResource
    {
       event Action<int, int> Changed;
       ResourceType Type { get; }
    }
}

