using UnityEngine;
using UnityEngine.UIElements;

public class PopUpUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement root;
    private VisualElement WinLoseNoticePage, WinLosePopUp;
    private Label TitleLabel, MainTextLabel;


    private void Awake()
    {
        #region
        root = uiDocument.rootVisualElement;
        WinLoseNoticePage = root.Q<VisualElement>("WinLoseNoticePage");
        WinLosePopUp = root.Q<VisualElement>("WinLosePopUp");

        TitleLabel = root.Q<Label>("TitleLabel");
        MainTextLabel = root.Q<Label>("MainTextLabel");

        var a1 = root.Q<Button>("ConfirmButton");
        a1.clicked += () => { ConfirmButton_clicked(); };
        #endregion
    }

    private void Start()
    {
        WinLoseNoticePage.AddToClassList("PageInvisibleState");
        WinLosePopUp.AddToClassList("PageSmallState");
        Hide();
    }

    public void Show()
    {
        WinLoseNoticePage.visible = true;
        WinLoseNoticePage.AddToClassList("PageVisibleState");
        WinLosePopUp.AddToClassList("PageBigState");
    }

    public void Hide()
    {
        WinLoseNoticePage.RemoveFromClassList("PageVisibleState");
        WinLosePopUp.RemoveFromClassList("PageBigState");
        WinLoseNoticePage.visible = false;
    }

    public void AddPopUp()
    {
        Show();
    }

    private void ConfirmButton_clicked()
    {
        Debug.Log("ConfirmButton2_clicked");
        Hide();
    }
}