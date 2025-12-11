using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField]
    private float amplitude = 0.02f; // độ cao rung

    [SerializeField]
    private float frequency = 8f; // tốc độ rung

    [SerializeField]
    private CharacterController controller;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        if (controller == null)
            return;

        if (controller.velocity.magnitude > 0.1f && controller.isGrounded)
        {
            float bobX = Mathf.Sin(Time.time * frequency) * amplitude;
            float bobY = Mathf.Cos(Time.time * frequency * 2) * amplitude * 0.5f;

            transform.localPosition = startPos + new Vector3(bobX, bobY, 0);
        }
        else
        {
            // Khi không di chuyển, trở về vị trí ban đầu
            transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                startPos,
                Time.deltaTime * 5f
            );
        }
    }
}
