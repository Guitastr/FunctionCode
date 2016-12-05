internal class ResourcesLoadManager : SingletonManager<ResourcesLoadManager>
{
    /// <summary>


    /// 资源加载，加载文件下所有类型的资源


    /// </summary>


    /// <param name="path">Resources文件夹下的子目录</param>


    /// <returns></returns>


    public static IEnumerable<object> ResourcesLoadAll(string path)
    {
        object[] prefabs = Resources.LoadAll(path);

        if (prefabs.Length == 0)
        {
            Debug.Log("资源不存在");
            return null;
        }
        for (int i = 0; i < prefabs.Length; i++)
        {
            Debug.Log(prefabs[i] + "资源找到了");
        }

        return prefabs;
    }
}