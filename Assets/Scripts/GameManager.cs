using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameSettings settings;
    public GameComponents components;

    public Button clickerButton;
    public Button upgradeButton;

    void Start()
    {
        if (settings == null || components == null) return;

        


        if (clickerButton != null)
        {
            Image buttonImage = clickerButton.GetComponent<Image>();
            if (components.clickerButtonSprite != null)
                buttonImage.sprite = components.clickerButtonSprite;
            buttonImage.color = components.clickerButtonColor;

        }

        if (upgradeButton != null)
        {
            Image buttonImage = upgradeButton.GetComponent<Image>();
            if (components.upgradeButtonSprite != null)
                buttonImage.sprite = components.upgradeButtonSprite;
            buttonImage.color = components.upgradeButtonColor;

        }
    }
}
