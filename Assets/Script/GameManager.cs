using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public AgentManager agentManager;
    
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 pos = hit.point;

                pos.y = 0f;

                agentManager.StartToRun(pos);
            }
        }
    }
}