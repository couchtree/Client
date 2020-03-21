using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Global
{
    public class PlayerBehavior : MonoBehaviour
    {
        // Use these if any other side effect occurs (other than losing points)
        public delegate void AddBehavior();
        public delegate void SubtractBehavior();

        public event AddBehavior AddBehaviorEvent;
        public event SubtractBehavior SubtractBehaviorEvent;

        private int _prevEvent;

        public int BehaviorPoints { get; private set; }

        public void AddPoints(int bonusAmount)
        {
            this.BehaviorPoints += bonusAmount;
            AddBehaviorEvent?.Invoke();

            _prevEvent = 1;
        }

        public void SubtractPoints(int penaltyAmount)
        {
            this.BehaviorPoints -= penaltyAmount;
            SubtractBehaviorEvent?.Invoke();

            _prevEvent = -1;
        }
    }
}
