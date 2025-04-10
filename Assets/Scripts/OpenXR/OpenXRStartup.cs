using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Management;

public class OpenXRStartup : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Initializing XR...");
        XRGeneralSettings.Instance.Manager.InitializeLoader();
        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");
        }
    }
}
