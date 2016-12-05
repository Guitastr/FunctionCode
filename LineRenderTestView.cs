using UnityEngine;

public class LineRenderTestView : MonoBehaviour
{
    /// <summary>


    ///     设置线段的顶点数，4个点确定3条线段


    /// </summary>


    private readonly int lineLength = 4;

    /// <summary>


    ///     线段渲染器


    /// </summary>


    private LineRenderer lineRenderer;

    /// <summary>


    ///     线段对象


    /// </summary>


    private GameObject LineRenderGameObject;

    /// <summary>


    ///     记录4个点，连接一条线段


    /// </summary>


    private Vector3 v0;

    private Vector3 v1;
    private Vector3 v2;
    private Vector3 v3;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        InitData();
        FindObject();
        SetLineRender();
    }

    private void InitData()
    {
        v0 = new Vector3(1.0f, 0.0f, 0.0f);
        v1 = new Vector3(2.0f, 0.0f, 0.0f);
        v2 = new Vector3(3.0f, 0.0f, 0.0f);
        v3 = new Vector3(4.0f, 0.0f, 0.0f);
    }

    private void FindObject()
    {
        LineRenderGameObject = GameObject.Find("ObjLine");

        lineRenderer = LineRenderGameObject.GetComponent<LineRenderer>();
    }

    /// <summary>


    ///     设置渲染线段


    /// </summary>


    private void SetLineRender()
    {
        lineRenderer.SetVertexCount(lineLength);
        lineRenderer.SetWidth(0.1f, 0.1f);

        lineRenderer.SetPosition(0, v0);
        lineRenderer.SetPosition(1, v1);
        lineRenderer.SetPosition(2, v2);
        lineRenderer.SetPosition(3, v3);
    }
}
