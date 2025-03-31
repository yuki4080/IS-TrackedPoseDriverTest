using UnityEngine;

public class SetupTestScene : MonoBehaviour
{
    [SerializeField] private GameObject CardboardStartup;
    [SerializeField] private GameObject OpenXRStartup;

    void Awake()
    {
#if UNITY_CARDBOARD
        Instantiate(CardboardStartup, Vector3.zero, Quaternion.identity, this.transform);
#elif UNITY_OPENXR
        Instantiate(OpenXRStartup, Vector3.zero, Quaternion.identity, this.transform);
#endif
    }
}
