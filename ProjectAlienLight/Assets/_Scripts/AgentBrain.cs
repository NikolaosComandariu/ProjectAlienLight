using UnityEngine;

namespace Agent.Core
{
    public class AgentBrain : MonoBehaviour
    {
        public Action bestAction { get; private set; }
        private AgentController agent;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            agent = GetComponent<AgentController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Decides which action is most sensible based on the situation from
        /// a list of available actions.
        /// </summary>
        /// <param name="actionsAvailable"></param>
        public void DecideBestAction(Action[] actionsAvailable)
        {

        }

        /// <summary>
        /// Scores an action based on how useful it is in the current situation.
        /// Takes different variables in consideration.
        /// </summary>
        /// <param name="action"></param>
        public void ScoreAction(Action action)
        {

        }
    }
}