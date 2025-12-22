// using UnityEngine;
// using UnityEngine.InputSystem;

// public class PauseInputSystem : MonoBehaviour
// {
//     [SerializeField]
//     private GameObject pausePanel;

//     [SerializeField]
//     private PlayerInput playerInput;

//     private bool isPaused;

//     public void OnPause(InputAction.CallbackContext context)
//     {
//         if (!context.performed)
//             return;

//         if (isPaused)
//             Resume();
//         else
//             Pause();
//     }

//     private void Pause()
//     {
//         isPaused = true;
//         pausePanel.SetActive(true);

//         Time.timeScale = 0f;

//         Cursor.lockState = CursorLockMode.None;
//         Cursor.visible = true;

//         playerInput.SwitchCurrentActionMap("UI");
//     }

//     public void Resume()
//     {
//         isPaused = false;
//         pausePanel.SetActive(false);

//         Time.timeScale = 1f;

//         Cursor.lockState = CursorLockMode.Locked;
//         Cursor.visible = false;

//         playerInput.SwitchCurrentActionMap("Player");
//     }
// }
