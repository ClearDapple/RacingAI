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

    [SerializeField] MyPickSO myPickSO;
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
        //header
        playerImg = root.Q<VisualElement>("playerImg");
        PlayerLabel = root.Q<Label>("PlayerLabel");
        AILabel = root.Q<Label>("AILabel");
        AIImg = root.Q<VisualElement>("AIImg");

        //body
        var a1 = Animal1Button = root.Q<Button>("Agent_01");
        var a2 = Animal2Button = root.Q<Button>("Agent_02");
        var a3 = Animal3Button = root.Q<Button>("Agent_03");
        var a4 = Animal4Button = root.Q<Button>("Agent_04");
        var a5 = Animal5Button = root.Q<Button>("Agent_05");
        var a6 = Animal6Button = root.Q<Button>("Agent_06");
        var a7 = Animal7Button = root.Q<Button>("Agent_07");

        a1.clicked += () => { AnimalButton_clicked(a1); };
        a2.clicked += () => { AnimalButton_clicked(a2); };
        a3.clicked += () => { AnimalButton_clicked(a3); };
        a4.clicked += () => { AnimalButton_clicked(a4); };
        a5.clicked += () => { AnimalButton_clicked(a5); };
        a6.clicked += () => { AnimalButton_clicked(a6); };
        a7.clicked += () => { AnimalButton_clicked(a7); };

        a1.style.backgroundImage = new StyleBackground(Animal1Img.texture);
        a2.style.backgroundImage = new StyleBackground(Animal2Img.texture);
        a3.style.backgroundImage = new StyleBackground(Animal3Img.texture);
        a4.style.backgroundImage = new StyleBackground(Animal4Img.texture);
        a5.style.backgroundImage = new StyleBackground(Animal5Img.texture);
        a6.style.backgroundImage = new StyleBackground(Animal6Img.texture);
        a7.style.backgroundImage = new StyleBackground(Animal7Img.texture);

        //footer
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

    private void AnimalButton_clicked(Button btn)
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = btn.style.backgroundImage;
        PlayerLabel.text = btn.name;

        myPickSO.playerName = btn.name;
        myPickSO.playerTexture = btn.style.backgroundImage.value.texture;
    }

    private void AnimalConfirmPageConfirmButton_clicked()
    {
        AnimamalButtonEnableFalse();
        AnimalConfirmPageConfirmButton.visible = false;
        AIConfirm();
    }

    private void AIConfirm()
    {
        gameManager.SelectAgentNumber(myPickSO.playerName);
        AILabel.text = myPickSO.AIName;

        AIImg.style.backgroundImage = null; ////so참조해서이미지 정하기

        StartButton.visible = true;
    }

    private void GameStartButton_clicked()
    {
        AnimalConfirmPage.RemoveFromClassList("AnimalConfirmPageDefaultState");
        OnGamePlayStartEvent?.Invoke();
    }

    //public void ScoreBoardText()
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