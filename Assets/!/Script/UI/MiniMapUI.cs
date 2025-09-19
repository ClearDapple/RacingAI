using UnityEngine;
using UnityEngine.UIElements;

public class MiniMapUI : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement root;
    private VisualElement MiniMapPage;

    private void Awake()
    {
        root = uiDocument.rootVisualElement;
        MiniMapPage = root.Q<VisualElement>();
    }

    public void Show()
    {
        MiniMapPage.visible = true;
    }

    public void Hide()
    {
        MiniMapPage.visible = false;
    }
}
