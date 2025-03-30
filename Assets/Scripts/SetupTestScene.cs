using UnityEngine;

public class SetupTestScene : MonoBehaviour
{
    [SerializeField] private GameObject CardboardStartup;
    
    void Awake()
    {
        #if UNITY_CARDBOARD
        Instantiate(CardboardStartup, Vector3.zero, Quaternion.identity, this.transform);
        #endif
    }
}
