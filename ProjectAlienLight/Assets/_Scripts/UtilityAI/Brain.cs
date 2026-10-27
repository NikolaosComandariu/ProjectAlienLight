using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace UtilityAI
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Sensor))]
    public class Brain : MonoBehaviour
    {
        public List<Action> actions;
        public Context context;

        void Awake()
        {
            context = new Context(this);

            foreach(var action in actions)
            {
                action.Initialize(context);
            }
        }

        void Update()
        {
            UpdateContext();

            Action bestAction = null;
            float highestUtility = float.MinValue;

            // Compares utility scores and saves the action with the
            // highest score as the best action. If it's not null, it
            // executes the action.
            foreach(var action in actions)
            {
                float utility = action.CalculateUtility(context);

                if(utility > highestUtility)
                {
                    highestUtility = utility;
                    bestAction = action;
                }
            }

            if(bestAction != null)
            {
                bestAction.Execute(context);
            }
        }

        void UpdateContext()
        {

        }
    }
}
