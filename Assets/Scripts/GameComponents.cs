using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GameComponents", menuName = "Settings/Game Components")]
public class GameComponents : ScriptableObject
{
    [Header("Clicker Button Settings")]
    public Sprite clickerButtonSprite;
    public Color clickerButtonColor = Color.yellow;
    public AudioClip clickerButtonSound;

    [Header("Uprgade Button Settings")]
    public Sprite upgradeButtonSprite;
    public Color upgradeButtonColor = Color.black;
    public AudioClip upgradeButtonSound;


}
