using UnityEngine;

public class Test_deltaTime : MonoBehaviour
{
    private float m_time = 1;

    private void Update()
    {
        RestrictionUpdate();
    }

    /// <summary>


    /// 限制刷新频率


    /// </summary>


    private void RestrictionUpdate(Action action = null)
    {
        m_time += Time.deltaTime;
        //        Debug.Log(m_time);




        if (!(m_time >= 1)) return;
        m_time = 0;
        Debug.Log("执行代码");
        if (action != null)
        {
            action();
        }
    }
}
