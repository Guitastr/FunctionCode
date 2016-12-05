using UnityEngine;

public class RotateAround : MonoBehaviour
{
    /// <summary>


    ///     移动的速度


    /// </summary>


    public float Speed;

    /// <summary>


    ///     围绕运动的目标物体


    /// </summary>


    public Transform TargeTransform;

    private void Update()
    {
        AroundRotateTransform(TargeTransform, transform, Speed);
    }

    /// <summary>


    /// 围绕物体旋转


    /// </summary>


    /// <param name="targeTran">目标物体</param>


    /// <param name="rotateTran">旋转物体</param>


    /// <param name="speed">旋转速度</param>


    public static void AroundRotateTransform(Transform targeTran, Transform rotateTran, float speed)
    {
        if (!targeTran) return;
        rotateTran.LookAt(targeTran);
        rotateTran.RotateAround(targeTran.position, Vector3.up, speed);
    }
}
