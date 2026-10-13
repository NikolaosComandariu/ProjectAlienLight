using UnityEngine;

namespace Agent.Core
{
    public abstract class Action : ScriptableObject // abstract so it can act as a parent class for Actions to inherit.
    {
        public string Name;
        private float _score;
        public float score
        {
            get { return _score; }
            set
            {
                this._score = Mathf.Clamp01(value); // Clamps score between 0 and 1.
            }
        }

        public Consideration[] considerations;

        public virtual void Awake()
        {
            score = 0;
        }

        public abstract void Execute();
    }
}