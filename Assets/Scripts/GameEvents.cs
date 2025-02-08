using System;
using UnityEngine;

public static class GameEvents
{
    public static Action<int> OnScoreChanged; 
    public static Action<int> OnUpgradePurchased; 
    public static Action<Vector2> OnClick;
}
