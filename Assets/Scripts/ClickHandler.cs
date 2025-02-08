using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public GameSettings settings; 
    public TMP_Text scoreText; 
    public Button clickButton;
    public RectTransform clickButtonRect; // Ссылка на кнопку (RectTransform)
    public Button upgradeButton;


    public int score = 0; 

    private bool canClick = true;

    void Start()
    {
        score = settings.startScore;
        UpdateScoreUI();

        GameEvents.OnUpgradePurchased += UpgradePointsPerClick;
    }

    private void OnDestroy()
    {
        // Отписываемся от события, чтобы избежать утечек памяти
        GameEvents.OnUpgradePurchased -= UpgradePointsPerClick;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!canClick) return;
        if (score >= settings.upgradeCost) {
            upgradeButton.image.color = Color.green;
        }

        canClick = false; 
        clickButton.interactable = false; 

        score += settings.pointsPerClick;

        GameEvents.OnScoreChanged?.Invoke(score);
        Vector2 localClickPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            clickButtonRect, eventData.position, eventData.pressEventCamera, out localClickPos
        );

        // Преобразуем в мировые координаты
        Vector2 worldClickPos = clickButtonRect.TransformPoint(localClickPos);

        // Вызываем событие с точной позицией клика
        GameEvents.OnClick?.Invoke(worldClickPos);
        UpdateScoreUI();


        StartCoroutine(Cooldown());
    }

    private void UpgradePointsPerClick(int newPointsPerClick)
    {
        settings.pointsPerClick = newPointsPerClick;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        if (scoreText)
            scoreText.text = score.ToString();

        if (score >= settings.upgradeCost)
        {
            upgradeButton.image.color = Color.green;
        }
        else
        {
            upgradeButton.image.color = Color.grey;
        }
    }

    private IEnumerator Cooldown()
    {
        // Меняем цвет кнопки (имитируем зажатость)
        Color originalColor = clickButton.image.color;
        clickButton.image.color = Color.gray;

        yield return new WaitForSeconds(settings.clickCooldown); 

        clickButton.image.color = originalColor;
        clickButton.interactable = true; 
        canClick = true;
    }
}
