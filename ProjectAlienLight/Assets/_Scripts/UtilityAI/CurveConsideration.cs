using UnityEngine;

namespace UtilityAI
{
    [CreateAssetMenu(menuName = "UtilityAI/Considerations/CurveConsideration")]
    public class CurveConsideration : Consideration
    {
        public AnimationCurve curve;
        public string contextKey;

        /// <summary>
        /// Get data from context by using key, evaluate
        /// the input value against the curve and return
        /// utility value.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override float Evaluate(Context context)
        {
            float inputValue = context.GetData<float>(contextKey);

            float utility = curve.Evaluate(inputValue);
            return Mathf.Clamp01(utility);
        }

        private void Reset()
        {
            curve = new AnimationCurve(
                new Keyframe(0f, 1f), // At normalized distance 0, utility is 1
                new Keyframe(1f, 0f) // At normalized distance 1, utility is 0 // TODO: Change it to a higher amount
                );
        }
    }
}