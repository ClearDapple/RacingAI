using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Label = UnityEngine.UIElements.Label;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public UnityEvent OnGamePlayStartEvent;

    public float LeftStartTime = Mathf.Clamp(3f, 0f, 3f);

    //UI Document 등록
    #region
    [SerializeField] private UIDocument uiDocument;
    private VisualElement root;

    private VisualElement Top;
    private VisualElement Top1, Top2, Top3;
    private Label PlayerLabel, AILabel;

    private VisualElement Mid;
    private Button Animal1, Animal2, Animal3, Animal4, Animal5, Animal6, Animal7;

    private VisualElement Bot;
    private Button ConfirmButton, StartButton;

    private Sprite playerImg, AIImg;
    public Sprite Animal1Img, Animal2Img, Animal3Img, Animal4Img, Animal5Img, Animal6Img, Animal7Img;
    #endregion


    private void Awake()
    {
        //UI Document 연결
        #region
        root = uiDocument.rootVisualElement;

        // Top Section
        Top = root.Q<VisualElement>("Top");
        Top1 = root.Q<VisualElement>("Top1");
        Top2 = root.Q<VisualElement>("Top2");
        Top3 = root.Q<VisualElement>("Top3");
        PlayerLabel = root.Q<Label>("PlayerLabel");
        AILabel = root.Q<Label>("AILabel");
        
        // Mid Section
        Mid = root.Q<VisualElement>("Mid");
        Animal1 = root.Q<Button>("Animal1");
        Animal2 = root.Q<Button>("Animal2");
        Animal3 = root.Q<Button>("Animal3");
        Animal4 = root.Q<Button>("Animal4");
        Animal5 = root.Q<Button>("Animal5");
        Animal6 = root.Q<Button>("Animal6");
        Animal7 = root.Q<Button>("Animal7");

        // Bot Section
        Bot = root.Q<VisualElement>("Bot");
        ConfirmButton = root.Q<Button>("Confirm");
        StartButton = root.Q<Button>("GameStart");

        Animal1.clicked += Animal1_clicked;
        Animal2.clicked += Animal2_clicked;
        Animal3.clicked += Animal3_clicked;
        Animal4.clicked += Animal4_clicked;
        Animal5.clicked += Animal5_clicked;
        Animal6.clicked += Animal6_clicked;
        Animal7.clicked += Animal7_clicked;
        ConfirmButton.clicked += ConfirmButton_clicked;
        StartButton.clicked += StartButton_clicked;
        #endregion
    }

    private void Start()
    {
        root = uiDocument.rootVisualElement;
        root.AddToClassList("DownState");
        root.AddToClassList("NomalState");
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
        root.AddToClassList("NomalState");
        Top1.style.backgroundImage = null;
        PlayerLabel.text = null;

        AnimamalButtonEnableTrue();
        ConfirmButton.visible = false;
        StartButton.visible = false;
    }

    private void Update()
    {
        if (LeftStartTime > 0)
        {
            LeftStartTime -= Time.deltaTime;
            //countdownText.text = Mathf.Ceil(LeftStartTime).ToString(); // 소수점 올림해서 3,2,1 표시
        }
        else
        {
            //countdownText.text = "Start!";
            // 여기서 게임 시작 로직을 넣을 수 있어요
        }
    }
    // Animal 1~7 Bttun Clicked Event
        #region
    private void Animal1_clicked()
    {
        ConfirmButton.visible = true;
        Top1.style.backgroundImage = new StyleBackground(Animal1Img);
        PlayerLabel.text = "Animal01";
    }
    private void Animal2_clicked()
    {
        ConfirmButton.visible = true;
        Top1.style.backgroundImage = new StyleBackground(Animal2Img);
        PlayerLabel.text = "Animal02";
    }
    private void Animal3_clicked()
    {
        ConfirmButton.visible = true;
        Top1.style.backgroundImage = new StyleBackground(Animal3Img);
        PlayerLabel.text = "Animal03";
    }
    private void Animal4_clicked()
    {
        ConfirmButton.visible = true;
        Top1.style.backgroundImage = new StyleBackground(Animal4Img);
        PlayerLabel.text = "Animal04";
    }
    private void Animal5_clicked()
    {
        ConfirmButton.visible = true;
        Top1.style.backgroundImage = new StyleBackground(Animal5Img);
        PlayerLabel.text = "Animal05";
    }
    private void Animal6_clicked()
    {
        ConfirmButton.visible = true;
        Top1.style.backgroundImage = new StyleBackground(Animal6Img);
        PlayerLabel.text = "Animal06";
    }
    private void Animal7_clicked()
    {
        ConfirmButton.visible = true;
        Top1.style.backgroundImage = new StyleBackground(Animal7Img);
        PlayerLabel.text = "Animal07";
    }
    #endregion

    private void ConfirmButton_clicked()
    {
        AnimamalButtonEnableFalse();
        ConfirmButton.visible = false;
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
        root.RemoveFromClassList("NomalState");
        new WaitForSeconds(3f);
        OnGamePlayStartEvent?.Invoke();
    }

    public void OnGamePlayEndEvent()
    {
        initialize();
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