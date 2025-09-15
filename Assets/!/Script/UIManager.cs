using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Label = UnityEngine.UIElements.Label;
using UnityEngine.Events;
using System.Security.Cryptography;

public class UIManager : MonoBehaviour
{
    public UnityEvent OnGamePlayStartEvent;
    public UnityEvent OnPopUpCloseEvent;

    [SerializeField] GameManager gameManager;

    [SerializeField] private UIDocument uiDocument;

    private VisualElement root;

    // AnimalConfirmPage 등록
    #region
    private VisualElement AnimalConfirmPage;

    private VisualElement playerImg, AIImg;
    private Label PlayerLabel, AILabel;

    private Button Animal1Button, Animal2Button, Animal3Button, Animal4Button, Animal5Button, Animal6Button, Animal7Button;

    private Button AnimalConfirmPageConfirmButton, StartButton;

    public Sprite Animal1Img, Animal2Img, Animal3Img, Animal4Img, Animal5Img, Animal6Img, Animal7Img;
    #endregion

    // WinLoseNoticePage 등록
    #region
    private VisualElement WinLoseNoticePage;
    private VisualElement WinLosePopUp;

    private VisualElement WinLoseNoticePageTop;
    private Label TitleLabel;

    private VisualElement WinLoseNoticePageMid;
    private Label MainTextLabel;

    private VisualElement WinLoseNoticePageBot;
    private Button WinLoseNoticePageConfirmButton;
    #endregion


    private void Awake()
    {
        root = uiDocument.rootVisualElement;
        AnimalConfirmPage = root.Q<VisualElement>("AnimalConfirmPage");
        WinLoseNoticePage = root.Q<VisualElement>("WinLoseNoticePage");

        //AnimalConfirmPage 연결
        #region
        playerImg = root.Q<VisualElement>("playerImg");
        AIImg = root.Q<VisualElement>("AIImg");
        PlayerLabel = root.Q<Label>("PlayerLabel");
        AILabel = root.Q<Label>("AILabel");

        var a1 = Animal1Button = root.Q<Button>("Animal1Button");
        var a2 = Animal2Button = root.Q<Button>("Animal2Button");
        var a3 = Animal3Button = root.Q<Button>("Animal3Button");
        var a4 = Animal4Button = root.Q<Button>("Animal4Button");
        var a5 = Animal5Button = root.Q<Button>("Animal5Button");
        var a6 = Animal6Button = root.Q<Button>("Animal6Button");
        var a7 = Animal7Button = root.Q<Button>("Animal7Button");

        a1.clicked += () => { Animal1_clicked(); };
        a2.clicked += () => { Animal2_clicked(); };
        a3.clicked += () => { Animal3_clicked(); };
        a4.clicked += () => { Animal4_clicked(); };
        a5.clicked += () => { Animal5_clicked(); };
        a6.clicked += () => { Animal6_clicked(); };
        a7.clicked += () => { Animal7_clicked(); };

        a1.style.backgroundImage = new StyleBackground(Animal1Img.texture);
        a2.style.backgroundImage = new StyleBackground(Animal2Img.texture);
        a3.style.backgroundImage = new StyleBackground(Animal3Img.texture);
        a4.style.backgroundImage = new StyleBackground(Animal4Img.texture);
        a5.style.backgroundImage = new StyleBackground(Animal5Img.texture);
        a6.style.backgroundImage = new StyleBackground(Animal6Img.texture);
        a7.style.backgroundImage = new StyleBackground(Animal7Img.texture);

        var b1 = AnimalConfirmPageConfirmButton = AnimalConfirmPage.Q<Button>("ConfirmButton");
        var b2 = StartButton = root.Q<Button>("GameStartButton");

        b1.clicked += () => { AnimalConfirmPageConfirmButton_clicked(); };
        b2.clicked += () => { GameStartButton_clicked(); };
        #endregion


        //WinLoseNoticePage 연결
        #region
        WinLosePopUp = WinLoseNoticePage.Q<VisualElement>("WinLosePopUp");
        TitleLabel = WinLoseNoticePage.Q<Label>("TitleLabel");
        MainTextLabel = WinLoseNoticePage.Q<Label>("MainTextLabel");

        var c1 = WinLoseNoticePage.Q<Button>("ConfirmButton");
        c1.clicked += () => { WinLoseNoticePageConfirmButton_clicked(); };
        #endregion
    }

    private void Start()
    {
        WinLoseNoticePage.visible = false;

        AnimalConfirmPage.AddToClassList("AnimalConfirmPageDownState");
        WinLoseNoticePage.AddToClassList("WinLoseNoticePageInvisibleState");
        WinLosePopUp.AddToClassList("WinLosePopUpSmallState");

        initialize();
    }

    public void initialize()
    {
        AnimalConfirmPage.visible = true;

        AnimalConfirmPage.AddToClassList("AnimalConfirmPageDefaultState");
        playerImg.style.backgroundImage = null;
        PlayerLabel.text = null;
        AIImg.style.backgroundImage = null;
        AILabel.text = null;

        AnimamalButtonEnableTrue();
        AnimalConfirmPageConfirmButton.visible = false;
        StartButton.visible = false;
    }

    // Animal 1~7 Bttun Clicked Event
    #region
    private void Animal1_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal1Img);
        PlayerLabel.text = "Animal01";
        gameManager.intPlayerChoice = 1;

    }
    private void Animal2_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal2Img);
        PlayerLabel.text = "Animal02";
        gameManager.intPlayerChoice = 2;
    }
    private void Animal3_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal3Img);
        PlayerLabel.text = "Animal03";
        gameManager.intPlayerChoice = 3;
    }
    private void Animal4_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal4Img);
        PlayerLabel.text = "Animal04";
        gameManager.intPlayerChoice = 4;
    }
    private void Animal5_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal5Img);
        PlayerLabel.text = "Animal05";
        gameManager.intPlayerChoice = 5;
    }
    private void Animal6_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal6Img);
        PlayerLabel.text = "Animal06";
        gameManager.intPlayerChoice = 6;
    }
    private void Animal7_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal7Img);
        PlayerLabel.text = "Animal07";
        gameManager.intPlayerChoice = 7;
    }
    #endregion

    private void AnimalConfirmPageConfirmButton_clicked()
    {
        AnimamalButtonEnableFalse();
        AnimalConfirmPageConfirmButton.visible = false;
        AIConfirm();
    }

    private void AIConfirm()
    {
        gameManager.selectAgentNumber();
        AILabel.text = "Animal0" + gameManager.intAIChoice.ToString();

        StartButton.visible = true;
    }

    private void GameStartButton_clicked()
    {
        AnimalConfirmPage.RemoveFromClassList("AnimalConfirmPageDefaultState");
        OnGamePlayStartEvent?.Invoke();
    }

    //public void ScoreBoardText(string a1, )
    //{
    //    TitleLabel.text = 

    //    MainTextLabel.text = $"1st ----- {gameManager.agentManager.rank1}\r\n"
    //                       + $"2nd ----- {agentManager.rank2}\r\n"
    //                       + $"3rd ----- {agentManager.rank3}\r\n"
    //                       + $"4th ----- {agentManager.rank4}\r\n"
    //                       + $"5th ----- {agentManager.rank5}\r\n"
    //                       + $"6th ----- {agentManager.rank6}\r\n"
    //                       + $"7th ----- {agentManager.rank7}";
    //    AddPopUp();
    //}



    public void AddPopUp()
    {
        WinLoseNoticePage.visible = true;
        WinLoseNoticePage.AddToClassList("WinLoseNoticePageDefaultState");
        WinLosePopUp.AddToClassList("WinLosePopUpDefaultState");
    }

    private void WinLoseNoticePageConfirmButton_clicked()
    {
        Debug.Log("ConfirmButton2_clicked");
        WinLoseNoticePage.RemoveFromClassList("WinLoseNoticePageDefaultState");
        WinLosePopUp.RemoveFromClassList("WinLosePopUpDefaultState");
        WinLoseNoticePage.visible = false;
        OnPopUpCloseEvent?.Invoke();
    }

    public void AnimamalButtonEnableTrue()
    {
        Animal1Button.enabledSelf = true;
        Animal2Button.enabledSelf = true;
        Animal3Button.enabledSelf = true;
        Animal4Button.enabledSelf = true;
        Animal5Button.enabledSelf = true;
        Animal6Button.enabledSelf = true;
        Animal7Button.enabledSelf = true;
    }
    public void AnimamalButtonEnableFalse()
    {
        Animal1Button.enabledSelf = false;
        Animal2Button.enabledSelf = false;
        Animal3Button.enabledSelf = false;
        Animal4Button.enabledSelf = false;
        Animal5Button.enabledSelf = false;
        Animal6Button.enabledSelf = false;
        Animal7Button.enabledSelf = false;
    }
}