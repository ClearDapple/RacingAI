using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] UIDocument agentConfirmUI;
    [SerializeField] UIDocument popUpUI;
    [SerializeField] UIDocument miniMapUI;
    [SerializeField] UIDocument rankingAgentsUI;


    //private void Start()
    //{
    //    HideAll();
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        HideAll();
    //    }
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        ShowAgentConfirmUI();
    //    }
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        ShowPopUpUI();
    //    }
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        ShowMiniMapUI();
    //    }
    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        ShowRankingAgentsUI();
    //    }
    //}

    public void HideAll()
    {
        agentConfirmUI.rootVisualElement.style.display = DisplayStyle.None;
        popUpUI.rootVisualElement.style.display = DisplayStyle.None; 
        miniMapUI.rootVisualElement.style.display = DisplayStyle.None;
        rankingAgentsUI.rootVisualElement.style.display = DisplayStyle.None;

        agentConfirmUI.sortingOrder = 0;
        popUpUI.sortingOrder = 0;
        miniMapUI.sortingOrder = 0;
        rankingAgentsUI.sortingOrder = 0;
    }

    public void ShowAgentConfirmUI()
    {
        HideAll();
        agentConfirmUI.sortingOrder = 1;
        agentConfirmUI.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void ShowPopUpUI()
    {
        HideAll();
        popUpUI.sortingOrder = 1;
        popUpUI.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void ShowMiniMapUI()
    {
        HideAll();
        miniMapUI.sortingOrder = 1;
        miniMapUI.rootVisualElement.style.display = DisplayStyle.Flex;
    }

    public void ShowRankingAgentsUI()
    {
        HideAll();
        rankingAgentsUI.sortingOrder = 1;
        rankingAgentsUI.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}