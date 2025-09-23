using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RankingData
{
    public string Name { get; set; }
    public string Time { get; set; }
    public Sprite Icon { get; set; }

    public RankingData(string name, string time, Sprite icon)
    {
        Name = name;
        Time = time;
        Icon = icon;
    }
}

public class RankingAgentsUI : MonoBehaviour
{
    public static event Action OnGameResetEvent;

    [SerializeField] UIDocument uiDocument;
    VisualElement root;

    MultiColumnListView listView;
    Button closeButton;


    private void Awake()
    {
        root = uiDocument.rootVisualElement;
        listView = root.Q<MultiColumnListView>();
        closeButton = root.Q<Button>("closeButton");
        closeButton.clicked += () => { CloseButton_clicked(); };
        PopUpUI.OnLeaderboardShowEvent += PopUpUI_OnLeaderboardShowEvent;
    }

    void Start()
    {
        root.AddToClassList("PageSmallState");
        Hide();
    }

    private void PopUpUI_OnLeaderboardShowEvent()
    {
        Show();
    }

    public void ShowRanking(List<RankingData> data)
    {
        List<RankingData> myDataList = data;
        Debug.Log("myDataList.count " + myDataList.Count);

        listView.columns.Add(new Column
        {
            name = "title",
            title = "�̸�",
            width = Length.Percent(40),
            makeCell = () =>
            {
                var label = new Label();
                label.style.flexGrow = 1;                                   // �� Ȯ�� ����
                label.style.whiteSpace = WhiteSpace.Normal;                 // �ٹٲ� ���
                label.style.height = new StyleLength(StyleKeyword.Auto);    // �ڵ� ����
                label.style.fontSize = 16;
                label.style.unityTextAlign = TextAnchor.MiddleLeft;
                return label;
            },
            bindCell = (element, index) =>
            {
                (element as Label).text = myDataList[index].Name;
            }
        });

        listView.columns.Add(new Column
        {
            name = "description",
            title = "�ɸ��ð�",
            width = Length.Percent(30),
            makeCell = () =>
            {
                var label = new Label();
                label.style.flexGrow = 1;                                // �� Ȯ�� ����
                label.style.whiteSpace = WhiteSpace.Normal;              // �ٹٲ� ���
                label.style.height = new StyleLength(StyleKeyword.Auto); // �ڵ� ����
                label.style.fontSize = 16;
                label.style.unityTextAlign = TextAnchor.MiddleLeft;
                return label;
            },
            bindCell = (element, index) =>
            {
                (element as Label).text = myDataList[index].Time;
            }
        });

        listView.columns.Add(new Column
        {
            name = "icon",
            title = "����",
            width = Length.Percent(30),
            makeCell = () => new Image { scaleMode = ScaleMode.ScaleToFit },
            bindCell = (element, index) =>
            {
                var image = element as Image;
                image.image = myDataList[index].Icon?.texture;
                image.style.justifyContent = Justify.Center; // ���� ���� ��� ����
                image.style.alignItems = Align.Center;       // ���� ���� ��� ����
            }
        });

        listView.fixedItemHeight = 30;
        listView.virtualizationMethod = CollectionVirtualizationMethod.FixedHeight;
        listView.itemsSource = null;
        listView.RefreshItems();
        listView.itemsSource = myDataList;
    }

    private void CloseButton_clicked()
    {
        Hide();
        OnGameResetEvent?.Invoke();
    }

    public void Show()
    {
        listView.visible = true;
        root.AddToClassList("PageBigState");
    }
    public void Hide()
    {
        root.RemoveFromClassList("PageBigState");
        listView.visible = false;
    }
}
