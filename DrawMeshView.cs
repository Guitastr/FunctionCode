using UnityEngine;

public class DrawMeshView : MonoBehaviour
{
    public Material Materials;

    private Vector3 v0;
    private Vector3 v1;
    private Vector3 v2;
    private Vector3 v3;
    private Vector3 v4;
    private Vector3 v5;

    private Vector3 u0;
    private Vector3 u1;
    private Vector3 u2;
    private Vector3 u3;
    private Vector3 u4;
    private Vector3 u5;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        InitData();

        GameObject faceObj = new GameObject("face");
        faceObj.transform.eulerAngles = new Vector3(0, 90, 0);
        //得到网格渲染器对象


        MeshFilter meshFilter = faceObj.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = faceObj.AddComponent<MeshRenderer>();

        //通过渲染器对象得到网格对象


        Mesh mesh = meshFilter.mesh;

        meshRenderer.material = Materials;
        meshRenderer.material.color = Color.blue;
        //设置三角形顶点的数组，6个点表示设置了两个三角形


        mesh.vertices = new Vector3[] { v0, v1, v2, v3, v4, v5 };

        //设置三角形面上的贴图比例


        mesh.uv = new Vector2[] { u0, u1, u2, u3, u4, u5 };

        //设置三角形索引，绘制三角形


        mesh.triangles = new int[] { 0, 1, 2, 3, 4, 5 };
    }

    private void InitData()
    {
        //构成三角形的三个顶点位置


        v0 = new Vector3(0, 0, 0);
        v1 = new Vector3(0, 5, 0);
        v2 = new Vector3(0, 0, 5);

        v3 = new Vector3(0, 0, 0);
        v4 = new Vector3(0, -5, 0);
        v5 = new Vector3(0, 0, -5);

        //构成三角形的贴图比例


        u0 = new Vector2(0, 0);
        u1 = new Vector2(0, 5);
        u2 = new Vector2(5, 5);

        u3 = new Vector2(0, 0);
        u4 = new Vector2(0, 1);
        u5 = new Vector2(1, 1);
    }
}
