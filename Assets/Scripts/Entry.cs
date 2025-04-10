using UnityEngine;
using UnityEngine.SceneManagement;

public class Entry : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Additive);
    }
}
