using Core.Garden;
using UnityEngine;
using UnityEngine.UI;

public class GardenSlot : MonoBehaviour
{
    [Header("Planting Images")]
    public Sprite seedImage;

    [Header("internal")]
    public bool seedPlanted;

    protected Image buttonImage;

    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        this.buttonImage = button.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void plantSeed()
    {
        if (seedPlanted)
        {
            return;
        }

        gameObject.AddComponent<NormalPlant>();
        this.buttonImage.sprite = this.seedImage;
        seedPlanted = true;
    }
}