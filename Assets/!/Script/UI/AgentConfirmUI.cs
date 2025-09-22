using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class AgentConfirmUI : MonoBehaviour
{
    public static event Action OnGamePlayStartEvent;

    [SerializeField] MyPickSO myPickSO;

    // AnimalConfirmPage 등록
    #region
    [SerializeField] private UIDocument uiDocument;
    private VisualElement root;
    private VisualElement AgentConfirmPage;

    private Label PlayerLabel, AILabel;
    private VisualElement playerImg, AIImg;
    public Sprite Agent1Img, Agent2Img, Agent3Img, Agent4Img, Agent5Img, Agent6Img, Agent7Img;

    private Button ConfirmButton, StartButton;
    #endregion

    public List<Button> ListButton = new List<Button>();


    private void Awake()
    {
        #region
        root = uiDocument.rootVisualElement;
        AgentConfirmPage = root.Q<VisualElement>("AgentConfirmPage");

        //header
        playerImg = root.Q<VisualElement>("playerImg");
        PlayerLabel = root.Q<Label>("PlayerLabel");
        AILabel = root.Q<Label>("AILabel");
        AIImg = root.Q<VisualElement>("AIImg");

        //body
        var Agent_01 = root.Q<Button>("Agent_01");
        var Agent_02 = root.Q<Button>("Agent_02");
        var Agent_03 = root.Q<Button>("Agent_03");
        var Agent_04 = root.Q<Button>("Agent_04");
        var Agent_05 = root.Q<Button>("Agent_05");
        var Agent_06 = root.Q<Button>("Agent_06");
        var Agent_07 = root.Q<Button>("Agent_07");

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
        RankingAgentsUI.OnGameResetEvent += RankingAgentsUI_OnGameResetEvent;
    }

    private void Start()
    {
        AgentConfirmPage.AddToClassList("PageDownState");
        initialize();
    }

    private void RankingAgentsUI_OnGameResetEvent()
    {
        initialize();
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

    public void Show()
    {
        AgentConfirmPage.visible = true;
        AgentConfirmPage.AddToClassList("PageUpState");
    }

    public void Hide()
    {
        AgentConfirmPage.RemoveFromClassList("PageUpState");
        AgentConfirmPage.visible = false;
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

        AILabel.text = myPickSO.AIName;
        AIImg.style.backgroundImage = myPickSO.AITexture;

        StartButton.visible = true;
    }

    private void GameStartButton_clicked()
    {
        Hide();
        OnGamePlayStartEvent?.Invoke();
    }

    public void SelectAgentNumber(string playerAgentName)
    {
        Debug.Log("playerAgentName: " + playerAgentName);
        int playerAgentNumber = int.Parse(playerAgentName.Split('_')[1]);

        int randomNumber = GetRandomNumberExcluding(playerAgentNumber);

        myPickSO.AIName = ListButton[randomNumber - 1].name;
        myPickSO.AITexture = ListButton[randomNumber - 1].style.backgroundImage.value.texture;

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
