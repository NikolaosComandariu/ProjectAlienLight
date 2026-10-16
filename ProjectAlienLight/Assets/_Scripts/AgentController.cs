using System;
using UnityEngine;

namespace Agent.Core
{
    public class AgentController : MonoBehaviour
    {
        public MoveController Mover { get; private set; }
        public AgentBrain AgentBrain { get; private set; }
        public Action[] actionsAvailable;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Mover = GetComponent<MoveController>();
            AgentBrain = GetComponent<AgentBrain>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}