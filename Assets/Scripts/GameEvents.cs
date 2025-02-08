using System;
using UnityEngine;

public static class GameEvents
{
    public static Action<int> OnScoreChanged; // Событие изменения очков
    public static Action<int> OnUpgradePurchased; // Событие покупки улучшения
    public static Action<Vector2> OnClick;
}
