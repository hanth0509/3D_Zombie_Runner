using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private FirstPersonController fpsController;

    [Header("Sensitivity")]
    [SerializeField]
    private float zoomSensitivityMultiplier = 0.3f;

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

    private float baseRotationSpeed;

    private void Awake()
    {
        inputs = new MyInputs();
    }

    private void Start()
    {
        if (fpsController == null)
            fpsController = GetComponentInParent<FirstPersonController>();

        baseRotationSpeed = fpsController.RotationSpeed;
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Zoom.started += OnZoomStarted;
        inputs.Player.Zoom.canceled += OnZoomCanceled;
    }

    private void OnDisable()
    {
        inputs.Player.Zoom.started -= OnZoomStarted;
        inputs.Player.Zoom.canceled -= OnZoomCanceled;
        inputs.Disable();

        ResetSensitivity();
    }

    private void OnZoomStarted(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        isZooming = true;
        fpsController.RotationSpeed = baseRotationSpeed * zoomSensitivityMultiplier;
    }

    private void OnZoomCanceled(UnityEngine.InputSystem.InputAction.CallbackContext ctx)
    {
        isZooming = false;
        ResetSensitivity();
    }

    private void ResetSensitivity()
    {
        fpsController.RotationSpeed = baseRotationSpeed;
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
