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

            // If there are colliders inside the detection collider on start, process them.
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
            foreach(var c in colliders)
            {
                ProcessTrigger(c, transform => detectedObjects.Add(transform));
            }
        }

        private void OnTriggerEnter(Collider other) 
        {
            ProcessTrigger(other, transform => detectedObjects.Add(transform));
        }

        private void OnTriggerExit(Collider other) 
        {
            ProcessTrigger(other, transform => detectedObjects.Remove(transform));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <param name="action"></param>
        private void ProcessTrigger(Collider other, Action<Transform> action) 
        {
            if (other.CompareTag("Untagged")) return;

            foreach(string t in targetTags)
            {
                if (other.CompareTag(t))
                {
                    action(other.transform);
                }
            }
        }

        public Transform GetClosestTarget(string tag)
        { 
            return null;
        }
    }
}