using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour
{
    public Camera initialCamera;
    public Camera vrCamera;
    public Camera pcCamera;

    void Start()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Additive);
    }
}
