using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Map;

namespace Core.Global
{
    public class PlayerBehavior : MonoBehaviour
    {
        // Use these if any other side effect occurs (other than losing points)
        public delegate void AddBehavior();
        public delegate void SubtractBehavior();

        public event AddBehavior AddBehaviorEvent;
        public event SubtractBehavior SubtractBehaviorEvent;

        public Player player; // Player which counts the score.

        private int _prevEvent;

        public int BehaviorPoints { get; private set; }

        private void OnStart()
        {
            if (player == null)
            {
                player = GetComponent<Player>();
                if (player == null)
                {
                    Debug.LogError("No player assigned!");
                }
                else
                {
                    Debug.LogWarning("Retrieve player from gameobject.");
                }

            }
        }

        public void AddPoints(int bonusAmount)
        {
            player.score += bonusAmount;
            AddBehaviorEvent?.Invoke();

            _prevEvent = 1;
        }

        public void SubtractPoints(int penaltyAmount)
        {
            player.score -= penaltyAmount;
            SubtractBehaviorEvent?.Invoke();

            _prevEvent = -1;
        }
    }
}
