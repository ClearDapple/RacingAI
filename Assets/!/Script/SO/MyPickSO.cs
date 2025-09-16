using UnityEngine;

[CreateAssetMenu(fileName = "MyPickSO", menuName = "Scriptable Objects/MyPickSO")]
public class MyPickSO : ScriptableObject
{
    public int playerRank;
    public string playerName;
    public Texture playerTexture;

    public int AIRank;
    public string AIName;
    public Texture AITexture;
}