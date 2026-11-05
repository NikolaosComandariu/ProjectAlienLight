using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

// Acts as a blackboard.
namespace UtilityAI
{
    public class Context
    {
        public Brain brain;
        public NavMeshAgent agent;
        public Transform transform;
        public Sensor sensor;

        readonly Dictionary<string, object> data = new();

        public Context(Brain brain)
        {
            if (brain == null) 
            { 
                Debug.LogException(new System.Exception("Brain is null in Context.cs")); 
                return; 
            }

            this.brain = brain; 
            this.agent = brain.gameObject.GetComponent<NavMeshAgent>();
            this.sensor = brain.gameObject.GetComponent<Sensor>();
        }

        // Get and set data using the dictionary.
        public T GetData<T>(string key) => data.TryGetValue(key, out var value) ? (T)value : default;
        public void SetData(string key, object value) => data[key] = value;
    }
}
