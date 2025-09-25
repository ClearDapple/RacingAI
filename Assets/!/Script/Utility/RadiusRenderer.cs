using UnityEngine;

//[RequireComponent(typeof(LineRenderer))]

public class RadiusRenderer : MonoBehaviour
{
    private LineRenderer line;
    
    public int segments = 100;
    public float radius;


    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = segments + 1;
        line.loop = true;
    }

    void Update()
    {
        Vector3 center = transform.position;

        for (int i = 0; i <= segments; i++)
        {
            float angle = i * 2 * Mathf.PI / segments;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            line.SetPosition(i, new Vector3(x, 0, z) + center);
        }
    }

    public void SetRadius(float newRadius)
    {
        radius = newRadius;
    }
    public void SetColor(Color nulll)
    {
        
    }

    public void SetColor(IAgentState state)
    {
        switch(state)
        {
            case IdleState:
                line.material.color = Color.lightSeaGreen;
                break;
            case AlertState:
                line.material.color = Color.orangeRed;

                break;
            case AttackState:
                line.material.color = Color.violetRed;
                break;
            case DeadState:
                line.material.color = Color.darkSlateGray;
                break;
            default:
                line.material.color = Color.lightCyan;
                break;
        }
    }
}