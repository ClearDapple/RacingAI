using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class AgentConfirmUI : MonoBehaviour
{
    public UnityEvent OnGamePlayStartEvent;

    [SerializeField] MyPickSO myPickSO;

    // AnimalConfirmPage 등록
    #region
    [SerializeField] private UIDocument uiDocument;
    private VisualElement root;
    private VisualElement AnimalConfirmPage;

    private Label PlayerLabel, AILabel;
    private VisualElement playerImg, AIImg;
    public Sprite Animal1Img, Animal2Img, Animal3Img, Animal4Img, Animal5Img, Animal6Img, Animal7Img;
    private Button Agent1Button, Agent2Button, Agent3Button, Agent4Button, Agent5Button, Agent6Button, Agent7Button;

    private Button ConfirmButton, StartButton;
    #endregion

    public List<Button> ListButton = new List<Button>();


    private void Awake()
    {
        #region
        root = uiDocument.rootVisualElement;
        AnimalConfirmPage = root.Q<VisualElement>("AnimalConfirmPage");

        //header
        playerImg = root.Q<VisualElement>("playerImg");
        PlayerLabel = root.Q<Label>("PlayerLabel");
        AILabel = root.Q<Label>("AILabel");
        AIImg = root.Q<VisualElement>("AIImg");

        //body
        var Agent_01 = Agent1Button = root.Q<Button>("Agent_01");
        var Agent_02 = Agent2Button = root.Q<Button>("Agent_02");
        var Agent_03 = Agent3Button = root.Q<Button>("Agent_03");
        var Agent_04 = Agent4Button = root.Q<Button>("Agent_04");
        var Agent_05 = Agent5Button = root.Q<Button>("Agent_05");
        var Agent_06 = Agent6Button = root.Q<Button>("Agent_06");
        var Agent_07 = Agent7Button = root.Q<Button>("Agent_07");

        Agent_01.clicked += () => { AgentButton_clicked(Agent_01); };
        Agent_02.clicked += () => { AgentButton_clicked(Agent_02); };
        Agent_03.clicked += () => { AgentButton_clicked(Agent_03); };
        Agent_04.clicked += () => { AgentButton_clicked(Agent_04); };
        Agent_05.clicked += () => { AgentButton_clicked(Agent_05); };
        Agent_06.clicked += () => { AgentButton_clicked(Agent_06); };
        Agent_07.clicked += () => { AgentButton_clicked(Agent_07); };

        ListButton.Add(Agent_01);
        ListButton.Add(Agent_02);
        ListButton.Add(Agent_03);
        ListButton.Add(Agent_04);
        ListButton.Add(Agent_05);
        ListButton.Add(Agent_06);
        ListButton.Add(Agent_07);

        //footer
        var b1 = ConfirmButton = root.Q<Button>("ConfirmButton");
        var b2 = StartButton = root.Q<Button>("GameStartButton");

        b1.clicked += () => { ConfirmButton_clicked(); };
        b2.clicked += () => { GameStartButton_clicked(); };
        #endregion
    }

    private void Start()
    {
        AnimalConfirmPage.AddToClassList("PageDownState");
        initialize();
    }

    public void Show()
    {
        AnimalConfirmPage.visible = true;
        AnimalConfirmPage.AddToClassList("PageUpState");
    }

    public void Hide()
    {
        AnimalConfirmPage.RemoveFromClassList("PageUpState");
        AnimalConfirmPage.visible = false;
    }

    public void initialize()
    {
        Show();

        playerImg.style.backgroundImage = null;
        PlayerLabel.text = null;

        AIImg.style.backgroundImage = null;
        AILabel.text = null;

        AllButtonsVisibleTrue();
        ConfirmButton.visible = false;
        StartButton.visible = false;
    }

    private void AgentButton_clicked(Button btn)
    {
        ConfirmButton.visible = true;

        playerImg.style.backgroundImage = btn.style.backgroundImage;
        PlayerLabel.text = btn.name;

        myPickSO.PlayerName = btn.name;
        myPickSO.PlayerTexture = btn.style.backgroundImage.value.texture;
    }

    private void ConfirmButton_clicked()
    {
        AllButtonsVisibleFalse();
        ConfirmButton.visible = false;
        AIConfirm();
    }

    private void AIConfirm()
    {
        SelectAgentNumber(myPickSO.PlayerName);
        //so의 정보를 집어넣기.
        //myPickSO.AITexture = ListButton[myPickSO.AIName].style.backgroundImage;
        //AIImg.style.backgroundImage = myPickSO.AITexture;
        StartButton.visible = true;
    }

    private void GameStartButton_clicked()
    {
        Hide();
        //OnGamePlayStartEvent?.Invoke();
    }

    public void SelectAgentNumber(string playerAgentName)
    {
        int playerAgentNumber = int.Parse(name.Split('_')[1]);

        int randomNumber = GetRandomNumberExcluding(playerAgentNumber);

        if (randomNumber < 10)
        {
            myPickSO.AIName = $"Agent_0{randomNumber}";
        }
        else
        {
            myPickSO.AIName = $"Agent_{randomNumber}";
        }

        int GetRandomNumberExcluding(int excludedNumber)
        {
            int[] availableNumbers = new int[6];
            int index = 0;

            for (int i = 1; i <= 7; i++)
            {
                if (i != excludedNumber)
                {
                    availableNumbers[index] = i;
                    index++;
                }
            }

            // 랜덤으로 하나 선택
            int randomIndex = Random.Range(0, availableNumbers.Length);
            return availableNumbers[randomIndex];
        }
    }

    void AllButtonsVisibleTrue()
    {
        foreach (Button btn in ListButton)
        {
            btn.enabledSelf = true;
        }
    }
    void AllButtonsVisibleFalse()
    {
        foreach (Button btn in ListButton)
        {
            btn.enabledSelf = false;
        }
    }
}
