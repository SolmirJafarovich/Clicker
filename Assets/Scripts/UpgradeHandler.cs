using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeHandler : MonoBehaviour
{
    public GameSettings settings;
    public ClickHandler clickHandler;
    public TMP_Text upgradeCostText;
    public TMP_Text clickerButtonText;
    public TMP_Text lvlButtonText;
    public Button upgradeButton;

    private int score = 0;

    void Start()
    {
        settings.pointsPerClick = settings.pointsPerClickStart;
        settings.clickLVL = settings.clickLVLStart;
        settings.upgradeCost = settings.upgradeCostStart;
        //

        UpdateUpgradeUI();


        GameEvents.OnScoreChanged += UpdateScore;
    }

    private void OnDestroy()
    {
        GameEvents.OnScoreChanged -= UpdateScore;
    }

    public void OnUpgradeClick()
    {
        
        if (clickHandler.score >= settings.upgradeCost)
        {
            clickHandler.score -= settings.upgradeCost; 
            settings.clickLVL++;
            settings.pointsPerClick += settings.upgradeIncrement; 

            settings.upgradeCost = Mathf.RoundToInt(settings.upgradeCost * settings.upgradeDifficulty);

            GameEvents.OnUpgradePurchased?.Invoke(settings.pointsPerClick);
            GameEvents.OnScoreChanged?.Invoke(score);

            UpdateUpgradeUI();
        }
    }

    private void UpdateScore(int newScore)
    {
        score = newScore;
        UpdateUpgradeUI();
    }

    private void UpdateUpgradeUI()
    {
        clickerButtonText.text = "+ " + settings.pointsPerClick;
        upgradeCostText.text = "UPGRADE " + settings.upgradeCost;
        lvlButtonText.text = "LV " + settings.clickLVL;
    }
}
