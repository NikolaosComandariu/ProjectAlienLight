using UnityEngine;

namespace UtilityAI
{
    public abstract class Consideration : ScriptableObject
    {
        /// <summary>
        /// Returns a normalized float value that represents
        /// how useful a factor is when making a decision on what
        /// action is best to perform.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract float Evaluate(Context context);
    }
}
