using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class OpenXRStartup : MonoBehaviour
{
    private Entry entry;
    private bool isVREnabled = false;

    void Start()
    {
        entry = FindFirstObjectByType<Entry>();

        StartCoroutine(InitializeVR());
    }

    public IEnumerator InitializeVR()
    {
        if (isVREnabled) yield break;

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            yield return XRGeneralSettings.Instance.Manager.InitializeLoader();
        }

        if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("XR started.");

            isVREnabled = true;

            entry.initialCamera.enabled = false;
            entry.vrCamera.enabled = true;
            entry.pcCamera.enabled = true;
        }
        else
        {
            Debug.LogError("Initializing XR Failed.");
        }
    }
}
