using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Label = UnityEngine.UIElements.Label;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public UnityEvent OnGamePlayStartEvent;
    public UnityEvent OnPopUpCloseEvent;

    public float LeftStartTime = Mathf.Clamp(3f, 0f, 3f);

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
        playerImg = AnimalConfirmPage.Q<VisualElement>("playerImg");
        AIImg = AnimalConfirmPage.Q<VisualElement>("AIImg");
        PlayerLabel = AnimalConfirmPage.Q<Label>("PlayerLabel");
        AILabel = AnimalConfirmPage.Q<Label>("AILabel");

        var m1 = Animal1Button.Q<Button>("Animal1Button");
        var m2 = Animal2Button.Q<Button>("Animal2Button");
        var m3 = Animal3Button.Q<Button>("Animal3Button");
        var m4 = Animal4Button.Q<Button>("Animal4Button");
        var m5 = Animal5Button.Q<Button>("Animal5Button");
        var m6 = Animal6Button.Q<Button>("Animal6Button");
        var m7 = Animal7Button.Q<Button>("Animal7Button");

        m1.clicked += () => { Animal1_clicked(); };
        Animal2Button.clicked += () => { Animal2_clicked(); };
        Animal3Button.clicked += () => { Animal3_clicked(); };
        Animal4Button.clicked += () => { Animal4_clicked(); };
        Animal5Button.clicked += () => { Animal5_clicked(); };
        Animal6Button.clicked += () => { Animal6_clicked(); };
        Animal7Button.clicked += () => { Animal7_clicked(); };

        Animal1Button.style.backgroundImage = new StyleBackground(Animal1Img.texture);
        Animal2Button.style.backgroundImage = new StyleBackground(Animal2Img.texture);
        Animal3Button.style.backgroundImage = new StyleBackground(Animal3Img.texture);
        Animal4Button.style.backgroundImage = new StyleBackground(Animal4Img.texture);
        Animal5Button.style.backgroundImage = new StyleBackground(Animal5Img.texture);
        Animal6Button.style.backgroundImage = new StyleBackground(Animal6Img.texture);
        Animal7Button.style.backgroundImage = new StyleBackground(Animal7Img.texture);

        var b1 = AnimalConfirmPageConfirmButton.Q<Button>("AnimalConfirmPageConfirmButton");
        var b2 = AnimalConfirmPage.Q<Button>("GameStartButton");

        b1.clicked += () => { AnimalConfirmPageConfirmButton_clicked(); };
        b2.clicked += () => { GameStartButton_clicked(); };
        #endregion


        //WinLoseNoticePage 연결
        #region
        WinLosePopUp = WinLoseNoticePage.Q<VisualElement>("WinLosePopUp");
        TitleLabel = WinLoseNoticePage.Q<Label>("TitleLabel");
        MainTextLabel = WinLoseNoticePage.Q<Label>("MainTextLabel");

        var q = WinLoseNoticePageConfirmButton = WinLoseNoticePage.Q<Button>("ConfirmButton");
        q.clicked += () => { WinLoseNoticePageConfirmButton_clicked(); };
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
    }
    private void Animal2_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal2Img);
        PlayerLabel.text = "Animal02";
    }
    private void Animal3_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal3Img);
        PlayerLabel.text = "Animal03";
    }
    private void Animal4_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal4Img);
        PlayerLabel.text = "Animal04";
    }
    private void Animal5_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal5Img);
        PlayerLabel.text = "Animal05";
    }
    private void Animal6_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal6Img);
        PlayerLabel.text = "Animal06";
    }
    private void Animal7_clicked()
    {
        AnimalConfirmPageConfirmButton.visible = true;
        playerImg.style.backgroundImage = new StyleBackground(Animal7Img);
        PlayerLabel.text = "Animal07";
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
        //ai가 내가 고르지 않은 동물 중 하나를 고른다.
        AILabel.text="Animal: " + Random.Range(1, 7).ToString();//확인용
        StartButton.visible = true;
    }

    private void GameStartButton_clicked()
    {
        AnimalConfirmPage.RemoveFromClassList("AnimalConfirmPageDefaultState");
        OnGamePlayStartEvent?.Invoke();
    }

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