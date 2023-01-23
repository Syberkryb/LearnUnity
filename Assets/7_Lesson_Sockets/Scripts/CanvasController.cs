using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public void NewClientScene()
    {
        SceneManager.LoadScene("Client", LoadSceneMode.Additive);
    }

    public void NewServerScene()
    {
        SceneManager.LoadScene("Server", LoadSceneMode.Additive);
    }
}