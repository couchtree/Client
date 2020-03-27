using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Map;

namespace UI
{
    /// <summary>
    /// Class to change the seedling state when the score of the player changes
    /// </summary>
    public class SeedlingStateView : MonoBehaviour
    {
        public Sprite happyMode;
        public Sprite happyBackground;
        public Sprite neutralMode;
        public Sprite neutralBackground;
        public Sprite sadMode;
        public Sprite sadBackground;

        public Image seedlingBackground;
        public Image seedlingSmiley;


        private Player player;

        public int happyModeThreshold; // score above this value is treated as happy mode
        public int sadModeThreshold; // score below this value is treated as sad mode

        // Start is called before the first frame update
        void Start()
        {
            player = Player.Instance;
            if (happyModeThreshold < sadModeThreshold)
            {
                // Enforce that sadModeThreshold < happyModeThreshold
                Debug.LogWarning("Thresholds were enforced to be in correct order.");
                int temp = happyModeThreshold;
                happyModeThreshold = sadModeThreshold;
                sadModeThreshold = temp;
            }
        }

        /// <summary>
        /// On every iteration the player's score is checked and the color and the smiley of the tree information panel are adapted accordingly
        /// </summary>
        void Update()
        {
            if (player.Score < sadModeThreshold)
            {
                seedlingSmiley.sprite = sadMode;
                seedlingBackground.sprite = sadBackground;
            }
            else if (player.Score > happyModeThreshold)
            {
                seedlingSmiley.sprite = happyMode;
                seedlingBackground.sprite = happyBackground;
            }
            else
            {
                seedlingSmiley.sprite = neutralMode;
                seedlingBackground.sprite = neutralBackground;
            }
        }
    }
}
