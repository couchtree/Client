using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core.Map;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (player.score < sadModeThreshold)
        {
            seedlingSmiley.sprite = sadMode;
            seedlingBackground.sprite = sadBackground;
        }
        else if (player.score > happyModeThreshold)
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
