using System;
using UnityEngine;

namespace Agent.Core
{
    public class AgentController : MonoBehaviour
    {
        public MoveController mover { get; private set; }
        public AgentBrain agentBrain { get; private set; }
        public Action[] actionsAvailable;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mover = GetComponent<MoveController>();
            agentBrain = GetComponent<AgentBrain>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}