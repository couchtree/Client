using System;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Interface every class providing which needs a level system must implement.
    /// </summary>
    public interface IXpProvider
    {
        int getCurrentXP();
    }

    /// <summary>
    /// Class to manage the level-system.
    /// It checks the Player-score regulary and triggers a level up if necessary.
    /// Also manages the score-levels necessary to reach a new level.
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        public Action OnNextLevelAchieved;  // Action which is triggered when a new level was reached

        public int CurrentLevel{get; private set;}  // Resembles the current level

        public int NextLevelXP{get;private set;} // Provides the next experience points to be reached in order to gain a level
        public IXpProvider XpProvider; // Script providing the current experience points
        private float nextActionTime = 0.0f; // Variable storing the next check time

        [Range(0.0f, 60.0f)]
        public float Period = 1.0f; // Periode in which the  is checked [s]

        /// <summary>
        /// Checks the XP-Provider on every Period time interval and increases the level if necessary.
        /// On every level-up the OnNextLevelAchieved-Action is triggered.
        /// </summary>
        private void Update()
        {
            if (Time.time > nextActionTime)  
            {
                nextActionTime = Time.time + Period;
                if (XpProvider.getCurrentXP() > NextLevelXP)
                {
                    setNextLevel();
                    OnNextLevelAchieved();
                }
            }
        }

        /// <summary>
        /// Increases the level and triggers the calculation of the new experience points to be reached
        /// </summary>
        private void setNextLevel()
        {
            CurrentLevel += 1;
            NextLevelXP = calculateNextLevelXP();
        }

        /// <summary>
        /// Calculates the new experience points necessary to reach the next level
        /// 
        /// <todo>Implement formular</todo>
        /// </summary>
        /// <returns>New experience points</returns>
        private int calculateNextLevelXP()
        {
            Debug.LogError("Calculate next level experience points here.");
            return CurrentLevel + 1;
        }

    }    
}

