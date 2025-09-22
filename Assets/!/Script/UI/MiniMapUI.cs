using System;
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
        AgentConfirmUI.OnGamePlayStartEvent += AgentConfirmUI_OnGamePlayStartEvent;
        AgentManager.OnGamePlayEndEvent += AgentManager_OnGamePlayEndEvent;
    }

    private void Start()
    {
        Hide();
    }

    private void AgentConfirmUI_OnGamePlayStartEvent()
    {
        Show();
    }
    private void AgentManager_OnGamePlayEndEvent()
    {
        Hide();
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
