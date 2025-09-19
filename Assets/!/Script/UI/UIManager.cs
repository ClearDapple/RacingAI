using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    //[SerializeField] AgentConfirmUI agentConfirmUI;
    //[SerializeField] PopUpUI popUpUI;
    //[SerializeField] MiniMapUI miniMapUI;
    //[SerializeField] RankingAgentsUI rankingAgentsUI;
    [SerializeField] UIDocument agentConfirmUI;
    [SerializeField] UIDocument popUpUI;
    [SerializeField] UIDocument miniMapUI;
    [SerializeField] UIDocument rankingAgentsUI;
   

    private void Start()
    {
        HideAll();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HideAll();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowAgentConfirmUI();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowPopUpUI();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ShowMiniMapUI();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShowRankingAgentsUI();
        }
    }

    public void HideAll()
    {
        /*
        agentConfirmUI.rootVisualElement.visible = false;
        popUpUI.rootVisualElement.visible = false; 
        rankingAgentsUI.rootVisualElement.visible = false;
        miniMapUI.rootVisualElement.visible = false;*/

        agentConfirmUI.sortingOrder = 0;
        popUpUI.sortingOrder = 0; 
        rankingAgentsUI.sortingOrder = 0; 
        miniMapUI.sortingOrder = 0; 
    }

    public void ShowAgentConfirmUI()
    {
        HideAll();
        agentConfirmUI.sortingOrder = 1; //rootVisualElement.visible = true;
    }

    public void ShowPopUpUI()
    {
        HideAll();
        popUpUI.sortingOrder = 1;
    }

    public void ShowMiniMapUI()
    {
        HideAll();
        miniMapUI.sortingOrder = 1;
    }

    public void ShowRankingAgentsUI()
    {
        HideAll();
        rankingAgentsUI.sortingOrder = 1;
    }
}