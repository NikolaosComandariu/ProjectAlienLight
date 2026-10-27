using UnityEngine;

namespace UtilityAI
{
    [CreateAssetMenu(menuName = "UtilityAI/Actions/IdleAction")]

    /// <summary>
    /// Sets the agent's destination to their current position.
    /// </summary>
    public class IdleAction : Action
    {
        public override void Execute(Context context)
        {
            context.agent.SetDestination(context.agent.transform.position);
        }
    }
}
