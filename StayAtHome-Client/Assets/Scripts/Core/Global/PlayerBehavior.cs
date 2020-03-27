using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Map;
using Core.DesignPattern;

namespace Core.Global
{
    /// <summary>
    /// Singleton to manage the adaptations of the player score
    /// 
    /// Each adaptation triggers the registered behaviour delegates which can therefore be used to trigger some action when the user performs some good or bad behaviour
    /// </summary>
    public class PlayerBehavior : Singleton<PlayerBehavior>
    {
        // Use these if any other side effect occurs (other than losing points)
        public delegate void AddBehavior();
        public delegate void SubtractBehavior();

        public event AddBehavior AddBehaviorEvent;
        public event SubtractBehavior SubtractBehaviorEvent;

        /// <summary>
        /// Add the bonus points to the players score and triggers all addBehaviour events
        /// </summary>
        /// <param name="bonusAmount">Number of points to add to the player score</param>
        public void AddPoints(int bonusAmount)
        {
            Player.Instance.ChangeScore(bonusAmount);
            AddBehaviorEvent?.Invoke();
        }

        /// <summary>
        /// Subtracts the penalty points from the players score and triggers all subtractBehaviour events
        /// </summary>
        /// <param name="penaltyAmount">Number of points to subtract from the player score</param>
        public void SubtractPoints(int penaltyAmount)
        {
            Player.Instance.ChangeScore(-penaltyAmount);
            SubtractBehaviorEvent?.Invoke();
        }
    }
}
