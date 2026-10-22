using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 0.02f;
    [SerializeField] private Transform playerBody;
    private PlayerControls controls;
    private float xRotation = 0f;

    private void Awake()
    {
        controls = new PlayerControls();

        if (playerBody == null)
            playerBody = transform.parent;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (playerBody == null)
            return;

        Vector2 lookInput = controls.Player.Look.ReadValue<Vector2>();
        float mouseX = lookInput.x * sensitivity;
        float mouseY = lookInput.y * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();
}