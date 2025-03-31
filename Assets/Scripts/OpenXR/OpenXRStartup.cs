using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Management;

public class OpenXRStartup : MonoBehaviour
{
    public InputAction toggleVR;

    private const float _defaultFieldOfView = 60.0f;
    private Camera _mainCamera;
    private bool _toggle = false;

    private void OnEnable() => toggleVR.Enable();
    private void OnDisable() => toggleVR.Disable();

    void Update()
    {
        if (toggleVR.WasPerformedThisFrame())
        {
            _toggle = !_toggle;

            if (_toggle)
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
            else
            {
                Debug.Log("Stopping XR...");
                XRGeneralSettings.Instance.Manager.StopSubsystems();
                Debug.Log("XR stopped.");

                Debug.Log("Deinitializing XR...");
                XRGeneralSettings.Instance.Manager.DeinitializeLoader();
                Debug.Log("XR deinitialized.");

                _mainCamera.ResetAspect();
                _mainCamera.fieldOfView = _defaultFieldOfView;
            }
        }
    }
}
