using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Map;
using Core.DesignPattern;

namespace Core.Global
{
    public class PlayerBehavior : Singleton<PlayerBehavior>
    {
        // Use these if any other side effect occurs (other than losing points)
        public delegate void AddBehavior();
        public delegate void SubtractBehavior();

        public event AddBehavior AddBehaviorEvent;
        public event SubtractBehavior SubtractBehaviorEvent;

        public void AddPoints(int bonusAmount)
        {
            Player.Instance.ChangeScore(bonusAmount);
            AddBehaviorEvent?.Invoke();
        }

        public void SubtractPoints(int penaltyAmount)
        {
            Player.Instance.ChangeScore(-penaltyAmount);
            SubtractBehaviorEvent?.Invoke();
        }
    }
}
