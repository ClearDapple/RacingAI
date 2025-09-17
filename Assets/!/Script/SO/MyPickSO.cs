using UnityEngine;

[CreateAssetMenu(fileName = "MyPickSO", menuName = "Scriptable Objects/MyPickSO")]
public class MyPickSO : ScriptableObject
{
    public int PlayerRank;
    public string PlayerName;
    public Texture2D PlayerTexture;

    public int AIRank;
    public string AIName;
    public Texture2D AITexture;

    public string Rank1;
}