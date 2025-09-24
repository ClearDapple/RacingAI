using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

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

        SetColor(Color.green);
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

    public void SetColor(Color lineColor)
    {
        line.material.color = lineColor;
    }
}