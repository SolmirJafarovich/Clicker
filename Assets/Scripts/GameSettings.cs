using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Start parametrs")]
    public int upgradeCostStart = 10;
    public int clickLVLStart = 0;
    public int pointsPerClickStart = 1;

    [Header("Uprgade")]
    public int upgradeCost = 10; 
    public int upgradeIncrement = 1;
    public int clickLVL = 0;

    [Header("Gameplay Settings")]
    [Range(0f, 100f)]public int startScore = 0;
    [Range(0f, 100f)] public float upgradeDifficulty = 2f;

    [Header("Click")]

    public int pointsPerClick = 1;
    public float clickCooldown = 1;

}
