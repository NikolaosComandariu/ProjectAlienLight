using UnityEngine;
using System;
using System.Collections.Generic;

namespace UtilityAI
{
    [RequireComponent(typeof(SphereCollider))]
    public class Sensor : MonoBehaviour
    {
        public float detectionRadius = 10f;
        public List<string> targetTags = new();

        readonly List<Transform> detectedObjects = new(10);
        SphereCollider sphereCollider;

        private void Start()
        {
            sphereCollider = GetComponent<SphereCollider>();
            sphereCollider.isTrigger = true;
            sphereCollider.radius = detectionRadius;
        }
    }
}