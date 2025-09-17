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

public class RankingAgents : MonoBehaviour
{
    [SerializeField] UIDocument uiDocument;
    VisualElement root;

    MultiColumnListView listView;


    void Start()
    {
        root = uiDocument.rootVisualElement;
        listView = root.Q<MultiColumnListView>();

        List<MyData> data = new List<MyData>();

        for (int i = 0; i < 5; i++)
        {
            Sprite mySprite = Resources.Load<Sprite>("cat/cat");
            MyData temp = new MyData("1", "2", mySprite);
            data.Add(temp);
        }
        ShowRanking(data);
    }

    public void ShowRanking(List<MyData> data)
    {
        List<MyData> myDataList = data;
        Debug.Log("myDataList.count " + myDataList.Count);

        //listView.style.width = Length.Percent(100);

        listView.columns.Add(new Column
        {
            name = "title",
            title = "이름",
            width = 150,
            makeCell = () => 
            {
                var label = new Label();
                label.style.flexGrow = 1;
                label.style.whiteSpace = WhiteSpace.Normal;
                label.style.height = 100;
                label.style.fontSize = 100;
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
            width = 250,
            makeCell = () =>
            {
                var label = new Label();
                label.style.flexGrow = 1;
                label.style.whiteSpace = WhiteSpace.Normal;
                label.style.height = 100;
                label.style.fontSize = 100;
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
            width = 300,
            makeCell = () => new Image { scaleMode = ScaleMode.ScaleToFit },
            bindCell = (element, index) =>
            {
                var image = element as Image;
                image.image = myDataList[index].Icon?.texture;
            }
        });

        listView.fixedItemHeight = 100;
        listView.virtualizationMethod = CollectionVirtualizationMethod.FixedHeight;
        listView.itemsSource = myDataList;
    }
}
