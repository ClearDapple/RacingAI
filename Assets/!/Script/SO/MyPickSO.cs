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
    public string Rank2;
    public string Rank3;
    public string Rank4;
    public string Rank5;
    public string Rank6;
    public string Rank7;

    public void initialize()
    {
        PlayerRank = 0;
        PlayerName = null;
        PlayerTexture = null;
        AIRank = 0;
        AIName = null;
        AITexture = null;
        Rank1 = null;
        Rank2 = null;
        Rank3 = null;
        Rank4 = null;
        Rank5 = null;
        Rank6 = null;
        Rank7 = null;
    }
}