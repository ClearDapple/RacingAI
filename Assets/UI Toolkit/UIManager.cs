using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Label = UnityEngine.UIElements.Label;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public UnityEvent OnGamePlayStartEvent;

    public float LeftStartTime = Mathf.Clamp(3f, 0f, 3f);

    [SerializeField] private UIDocument uiDocument;

    private VisualElement root;

    // AnimalConfirmPage 등록
    #region
    private VisualElement root01;

    private VisualElement Top1;
    private VisualElement Top11, Top12, Top13;
    private Label PlayerLabel, AILabel;

    private VisualElement Mid1;
    private Button Animal1, Animal2, Animal3, Animal4, Animal5, Animal6, Animal7;

    private VisualElement Bot1;
    private Button ConfirmButton1, StartButton;

    private Sprite playerImg, AIImg;
    public Sprite Animal1Img, Animal2Img, Animal3Img, Animal4Img, Animal5Img, Animal6Img, Animal7Img;
    #endregion

    // WinLoseNoticePage 등록
    #region
    private VisualElement root02;
    private VisualElement WinLosePopUp;

    private VisualElement Top2;
    private Label TitleLabel;

    private VisualElement Mid2;
    private Label MainTextLabel;

    private VisualElement Bot2;
    private Button ConfirmButton2;
    #endregion


    private void Awake()
    {
        root = uiDocument.rootVisualElement.Q<VisualElement>("MainRoot");
        root01 = root.Q<VisualElement>("AnimalConfirmPage");
        root02 = root.Q<VisualElement>("WinLoseNoticePage");

        //AnimalConfirmPage 연결
        #region
        // Top Section
        Top1 = root01.Q<VisualElement>("Top");
        Top11 = root01.Q<VisualElement>("Top1");
        Top12 = root01.Q<VisualElement>("Top2");
        Top13 = root01.Q<VisualElement>("Top3");
        PlayerLabel = root01.Q<Label>("PlayerLabel");
        AILabel = root01.Q<Label>("AILabel");
        
        // Mid Section
        Mid1 = root01.Q<VisualElement>("Mid");
        Animal1 = root01.Q<Button>("Animal1Button");
        Animal2 = root01.Q<Button>("Animal2Button");
        Animal3 = root01.Q<Button>("Animal3Button");
        Animal4 = root01.Q<Button>("Animal4Button");
        Animal5 = root01.Q<Button>("Animal5Button");
        Animal6 = root01.Q<Button>("Animal6Button");
        Animal7 = root01.Q<Button>("Animal7Button");

        // Bot Section
        Bot1 = root01.Q<VisualElement>("Bot");
        ConfirmButton1 = root01.Q<Button>("ConfirmButton");
        StartButton = root01.Q<Button>("GameStartButton");

        Animal1.clicked += Animal1_clicked;
        Animal2.clicked += Animal2_clicked;
        Animal3.clicked += Animal3_clicked;
        Animal4.clicked += Animal4_clicked;
        Animal5.clicked += Animal5_clicked;
        Animal6.clicked += Animal6_clicked;
        Animal7.clicked += Animal7_clicked;
        ConfirmButton1.clicked += ConfirmButton_clicked;
        StartButton.clicked += StartButton_clicked;
        #endregion
        //WinLoseNoticePage 연결
        #region
        WinLosePopUp = root02.Q<VisualElement>("WinLosePopUp");

        // Top Section
        Top2 = root02.Q<VisualElement>("Top");
        TitleLabel = root02.Q<Label>("TitleLabel");

        // Mid Section
        Mid2 = root02.Q<VisualElement>("Mid");
        MainTextLabel = root02.Q<Label>("MainTextLabel");
        
        // Bot Section
        Bot2 = root02.Q<VisualElement>("Bot");
        ConfirmButton2 = root02.Q<Button>("ConfirmButton");

        ConfirmButton2.clicked += ConfirmButton2_clicked;
        #endregion
    }

    private void Start()
    {
        root01.AddToClassList("AnimalConfirmPageDownState");
        root02.AddToClassList("WinLoseNoticePageInvisibleState");
        root02.AddToClassList("WinLosePopUpSmallState");
        Animal1.style.backgroundImage = new StyleBackground(Animal1Img.texture);
        Animal2.style.backgroundImage = new StyleBackground(Animal2Img.texture);
        Animal3.style.backgroundImage = new StyleBackground(Animal3Img.texture);
        Animal4.style.backgroundImage = new StyleBackground(Animal4Img.texture);
        Animal5.style.backgroundImage = new StyleBackground(Animal5Img.texture);
        Animal6.style.backgroundImage = new StyleBackground(Animal6Img.texture);
        Animal7.style.backgroundImage = new StyleBackground(Animal7Img.texture);
        initialize();
    }

    public void initialize()
    {
        LeftStartTime = 3f;
        new WaitForSeconds(1f);
        root01.AddToClassList("AnimalConfirmPageDefaultState");
        Top11.style.backgroundImage = null;
        PlayerLabel.text = null;

        AnimamalButtonEnableTrue();
        ConfirmButton1.visible = false;
        StartButton.visible = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            AddPopUp();
        }
    }

    // Animal 1~7 Bttun Clicked Event
    #region
    private void Animal1_clicked()
    {
        ConfirmButton1.visible = true;
        Top11.style.backgroundImage = new StyleBackground(Animal1Img);
        PlayerLabel.text = "Animal01";
    }
    private void Animal2_clicked()
    {
        ConfirmButton1.visible = true;
        Top11.style.backgroundImage = new StyleBackground(Animal2Img);
        PlayerLabel.text = "Animal02";
    }
    private void Animal3_clicked()
    {
        ConfirmButton1.visible = true;
        Top11.style.backgroundImage = new StyleBackground(Animal3Img);
        PlayerLabel.text = "Animal03";
    }
    private void Animal4_clicked()
    {
        ConfirmButton1.visible = true;
        Top11.style.backgroundImage = new StyleBackground(Animal4Img);
        PlayerLabel.text = "Animal04";
    }
    private void Animal5_clicked()
    {
        ConfirmButton1.visible = true;
        Top11.style.backgroundImage = new StyleBackground(Animal5Img);
        PlayerLabel.text = "Animal05";
    }
    private void Animal6_clicked()
    {
        ConfirmButton1.visible = true;
        Top11.style.backgroundImage = new StyleBackground(Animal6Img);
        PlayerLabel.text = "Animal06";
    }
    private void Animal7_clicked()
    {
        ConfirmButton1.visible = true;
        Top11.style.backgroundImage = new StyleBackground(Animal7Img);
        PlayerLabel.text = "Animal07";
    }
    #endregion

    private void ConfirmButton_clicked()
    {
        AnimamalButtonEnableFalse();
        ConfirmButton1.visible = false;
        AIConfirm();
    }

    private void AIConfirm()
    {
        new WaitForSeconds(1f);
        //ai가 내가 고르지 않은 동물 중 하나를 고른다.
        AILabel.text="Animal: " + Random.Range(1, 7).ToString();//확인용
        new WaitForSeconds(1f);
        StartButton.visible = true;
    }

    private void StartButton_clicked()
    {
        root01.RemoveFromClassList("AnimalConfirmPageDefaultState");
        new WaitForSeconds(3f);
        OnGamePlayStartEvent?.Invoke();
    }

    public void AddPopUp()
    {
        root02.AddToClassList("WinLoseNoticePageDefaultState");
        root02.AddToClassList("WinLosePopUpDefaultState");
    }

    public void ConfirmButton2_clicked()
    {
        Debug.Log("ConfirmButton2_clicked");
        root02.RemoveFromClassList("WinLoseNoticePageDefaultState");
        root02.RemoveFromClassList("WinLosePopUpDefaultState");
    }

    public void AnimamalButtonEnableTrue()
    {
        Animal1.enabledSelf = true;
        Animal2.enabledSelf = true;
        Animal3.enabledSelf = true;
        Animal4.enabledSelf = true;
        Animal5.enabledSelf = true;
        Animal6.enabledSelf = true;
        Animal7.enabledSelf = true;
    }
    public void AnimamalButtonEnableFalse()
    {
        Animal1.enabledSelf = false;
        Animal2.enabledSelf = false;
        Animal3.enabledSelf = false;
        Animal4.enabledSelf = false;
        Animal5.enabledSelf = false;
        Animal6.enabledSelf = false;
        Animal7.enabledSelf = false;
    }
}