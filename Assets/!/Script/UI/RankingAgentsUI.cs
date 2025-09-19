using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MyData
{
    public string Name { get; set; }
    public string Time { get; set; }
    public Sprite Icon { get; set; }

    public MyData(string name, string time, Sprite icon)
    {
        Name = name;
        Time = time;
        Icon = icon;
    }
}

public class RankingAgentsUI : MonoBehaviour
{
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
    }

    void Start()
    {
        root.AddToClassList("PageSmallState");
        Show();
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


    public void ShowRanking(List<MyData> data)
    {
        List<MyData> myDataList = data;
        Debug.Log("myDataList.count " + myDataList.Count);

        listView.columns.Add(new Column
        {
            name = "title",
            title = "이름",
            width = Length.Percent(40),
            makeCell = () =>
            {
                var label = new Label();
                label.style.flexGrow = 1;                                   // 셀 확장 가능
                label.style.whiteSpace = WhiteSpace.Normal;                 // 줄바꿈 허용
                label.style.height = new StyleLength(StyleKeyword.Auto);    // 자동 높이
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
            title = "걸린시간",
            width = Length.Percent(30),
            makeCell = () =>
            {
                var label = new Label();
                label.style.flexGrow = 1;                                // 셀 확장 가능
                label.style.whiteSpace = WhiteSpace.Normal;              // 줄바꿈 허용
                label.style.height = new StyleLength(StyleKeyword.Auto); // 자동 높이
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
            title = "사진",
            width = Length.Percent(30),
            makeCell = () => new Image { scaleMode = ScaleMode.ScaleToFit },
            bindCell = (element, index) =>
            {
                var image = element as Image;
                image.image = myDataList[index].Icon?.texture;
                image.style.justifyContent = Justify.Center; // 세로 방향 가운데 정렬
                image.style.alignItems = Align.Center;       // 가로 방향 가운데 정렬
            }
        });

        listView.fixedItemHeight = 30;
        listView.virtualizationMethod = CollectionVirtualizationMethod.FixedHeight;
        listView.itemsSource = myDataList;
    }

    private void CloseButton_clicked()
    {
        Hide();
    }
}
