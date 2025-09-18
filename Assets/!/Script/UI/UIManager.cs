using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Label = UnityEngine.UIElements.Label;
using UnityEngine.Events;
using System.Security.Cryptography;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public UnityEvent OnGamePlayStartEvent;
    public UnityEvent OnPopUpCloseEvent;

    [SerializeField] MyPickSO myPickSO;
    [SerializeField] GameManager gameManager;

    public List<Button> ListButton = new List<Button>();

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
        var Agent_01 = Animal1Button = root.Q<Button>("Agent_01");
        var Agent_02 = Animal2Button = root.Q<Button>("Agent_02");
        var Agent_03 = Animal3Button = root.Q<Button>("Agent_03");
        var Agent_04 = Animal4Button = root.Q<Button>("Agent_04");
        var Agent_05 = Animal5Button = root.Q<Button>("Agent_05");
        var Agent_06 = Animal6Button = root.Q<Button>("Agent_06");
        var Agent_07 = Animal7Button = root.Q<Button>("Agent_07");

        Agent_01.clicked += () => { AnimalButton_clicked(Agent_01); };
        Agent_02.clicked += () => { AnimalButton_clicked(Agent_02); };
        Agent_03.clicked += () => { AnimalButton_clicked(Agent_03); };
        Agent_04.clicked += () => { AnimalButton_clicked(Agent_04); };
        Agent_05.clicked += () => { AnimalButton_clicked(Agent_05); };
        Agent_06.clicked += () => { AnimalButton_clicked(Agent_06); };
        Agent_07.clicked += () => { AnimalButton_clicked(Agent_07); };

        ListButton.Add(Agent_01);
        ListButton.Add(Agent_02);
        ListButton.Add(Agent_03);
        ListButton.Add(Agent_04);
        ListButton.Add(Agent_05);
        ListButton.Add(Agent_06);
        ListButton.Add(Agent_07);

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

        AnimalConfirmPage.AddToClassList("PageDownState");
        WinLoseNoticePage.AddToClassList("PageInvisibleState");
        WinLosePopUp.AddToClassList("PageSmallState");

        initialize();
    }

    public void initialize()
    {
        AnimalConfirmPage.visible = true;

        AnimalConfirmPage.AddToClassList("PageUpState");
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

        myPickSO.PlayerName = btn.name;
        myPickSO.PlayerTexture = btn.style.backgroundImage.value.texture;
    }

    private void AnimalConfirmPageConfirmButton_clicked()
    {
        AnimamalButtonEnableFalse();
        AnimalConfirmPageConfirmButton.visible = false;
        AIConfirm();
    }

    private void AIConfirm()
    {


        gameManager.SelectAgentNumber(myPickSO.PlayerName);

        //myPickSO.AITexture = ListButton[myPickSO.AIName].style.backgroundImage;

        //AIImg.style.backgroundImage = myPickSO.AITexture;

        StartButton.visible = true;
    }

    private void GameStartButton_clicked()
    {
        AnimalConfirmPage.RemoveFromClassList("PageUpState");
        OnGamePlayStartEvent?.Invoke();
    }

    public void OnGUI()
    {
        AddPopUp();
    }

    public void ScoreBoardText()
    {
        //TitleLabel.text =

        //MainTextLabel.text = $"1st ----- {gameManager.agentManager.rank1}\r\n"
        //                   + $"2nd ----- {agentManager.rank2}\r\n"
        //                   + $"3rd ----- {agentManager.rank3}\r\n"
        //                   + $"4th ----- {agentManager.rank4}\r\n"
        //                   + $"5th ----- {agentManager.rank5}\r\n"
        //                   + $"6th ----- {agentManager.rank6}\r\n"
        //                   + $"7th ----- {agentManager.rank7}";
        AddPopUp();
    }

    public void AddPopUp()
    {
        WinLoseNoticePage.visible = true;
        WinLoseNoticePage.AddToClassList("PageVisibleState");
        WinLosePopUp.AddToClassList("PageBigState");
    }

    private void WinLoseNoticePageConfirmButton_clicked()
    {
        Debug.Log("ConfirmButton2_clicked");
        WinLoseNoticePage.RemoveFromClassList("PageVisibleState");
        WinLosePopUp.RemoveFromClassList("PageBigState");
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