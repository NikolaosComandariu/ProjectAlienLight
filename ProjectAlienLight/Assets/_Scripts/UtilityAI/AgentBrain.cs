using UnityEngine;

namespace Agent.Core
{
    public class AgentBrain : MonoBehaviour
    {
        public Action BestAction { get; private set; }
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
        /// Loops through all available actions, compares scores, and
        /// returns the highest scoring action.
        /// </summary>
        /// <param name="actionsAvailable"></param>
        public void DecideBestAction(Action[] actionsAvailable)
        {
            float score = 0f;
            int nextBestActionIndex = 0;

            for (int i = 0; i < actionsAvailable.Length; i++)
            {
                if (ScoreAction(actionsAvailable[i]) > score)
                {
                    nextBestActionIndex = i;
                    score = actionsAvailable[i].Score;
                }
            }

            BestAction = actionsAvailable[nextBestActionIndex];
        }

        /// <summary>
        /// Loops through all considerations of the action, score
        /// all the considerations, and average the consideration scores
        /// which is equal to the action score.
        /// </summary>
        /// <param name="action"></param>
        public float ScoreAction(Action action)
        {
            float score = 1f;

            for(int i  = 0; i < action.considerations.Length; i++)
            {
                float considerationScore = action.considerations[i].ScoreConsideration();
                score *= considerationScore; // Accumulate score.

                if(score == 0) // Action is redundant.
                {
                    action.Score = 0;
                    return action.Score;
                }
            }

            // Averaging scheme of overall score.
            float originalScore = score;
            float modFactor = 1 - (1 / action.considerations.Length);
            float makeupValue = (1 - originalScore) * modFactor;
            action.Score = originalScore + (makeupValue * originalScore);

            return action.Score;
        }
    }
}