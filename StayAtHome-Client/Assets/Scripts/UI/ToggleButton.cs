using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to toggle the sprite of a button
/// </summary>
public class ToggleButton : MonoBehaviour
{
    public Sprite onSprite;     // Sprite displayed when button is in 'on' state
    public Sprite offSprite;    // Sprite displayed when button in in 'off' state

    public Image image;         // Image where Sprite should be swapped
    public bool defaultState = true; // Default state of the Image/Button
    private bool toggle = true; // Track current state of the button

    private void OnStart()
    {
        // invert default state as toggle is inverted at the start of toggleImage-methode
        toggle = !defaultState;
        toggleImage();
    }

    /// <summary>
    /// Toggles the active sprite of the provided image
    /// </summary>
    public void toggleImage()
    {
        toggle = !toggle;
        if (toggle)
        {
            image.sprite = onSprite;
        }
        else
        {
            image.sprite = offSprite;
        }
    }
}
