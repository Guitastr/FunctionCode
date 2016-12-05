using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //摄像机参照的模型


    public Transform target;

    //摄像机距离模型的默认距离


    private readonly float distance = 2.0f;

    //鼠标在x轴和y轴方向移动的角度


    private float x;
    private float y;

    //限制旋转角度的最小值与最大值


    private readonly float yMinLimit = -20.0f;
    private readonly float yMaxLimit = 80.0f;

    //x和y轴方向的移动速度


    private readonly float xSpeed = 5f;
    private float ySpeed = 120.0f;

    private void Start()
    {
        //初始化x和y轴角度等于参照模型的角度


        Vector2 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (gameObject.GetComponent<Rigidbody>())
        {
            gameObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    private void LateUpdate()
    {
        if (target && Input.GetMouseButton(0))
        {
            //根据鼠标的移动修改摄像机的角度


            x += Input.GetAxis("Mouse X") * xSpeed; //*0.02f;

            y -= Input.GetAxis("Mouse Y") * xSpeed; //*0.02f;

            //限制y旋转的角度


            y = Clamangle(y, yMinLimit, yMaxLimit);
            var rotation = Quaternion.Euler(y, x, 0);
            // rotation*new Vector3(0.0f, 0.0f, (-distance)) + 


            var position = rotation * new Vector3(0.0f, 0.0f, (-distance)); // + target.position;

            //            //设置模型的位置与旋转


            transform.rotation = rotation;
            transform.position = position;
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("摄像机的X轴" + x);
        GUILayout.Label("摄像机的Y轴" + y);
    }

    private float Clamangle(float angle, float min, float max)
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
}