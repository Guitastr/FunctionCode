public class Thread_Test : MonoBehaviour
{
    private void Start()
    {
        Thread t = new Thread(new ThreadStart(Cal));
        t.Start();
    }

    private void Cal()
    {
        print("新线程被开启");
        GameObject.Find("Cube");
    }
}
