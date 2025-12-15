using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    [Header("FOV")]
    [SerializeField]
    private float zoomOutFOV = 40f;

    [SerializeField]
    private float zoomInFOV = 20f;

    [Header("Zoom")]
    [SerializeField]
    private float zoomSpeed = 10f;

    private MyInputs inputs;
    private bool isZooming;

    private void Awake()
    {
        inputs = new MyInputs();
    }

    private void OnEnable()
    {
        inputs.Enable();

        // GIỮ chuột
        inputs.Player.Zoom.started += OnZoomStarted;
        // NHẢ chuột
        inputs.Player.Zoom.canceled += OnZoomCanceled;
    }

    private void OnDisable()
    {
        inputs.Player.Zoom.started -= OnZoomStarted;
        inputs.Player.Zoom.canceled -= OnZoomCanceled;
        inputs.Disable();
    }

    private void OnZoomStarted(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Debug.Log("ZOOM STARTED");
        isZooming = true;
    }

    private void OnZoomCanceled(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        Debug.Log("ZOOM CANCETED");
        isZooming = false;
    }

    private void Update()
    {
        float targetFOV = isZooming ? zoomInFOV : zoomOutFOV;

        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(
            virtualCamera.m_Lens.FieldOfView,
            targetFOV,
            Time.deltaTime * zoomSpeed
        );
    }
}
