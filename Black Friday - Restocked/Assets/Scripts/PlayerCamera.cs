using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float Sensitivity
    {
        get { return MouseSensitivity; }
        set { MouseSensitivity = value; }
    }

    [SerializeField, Range(0.1f, 9f)] float MouseSensitivity = 2f;
    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
    [SerializeField, Range(0f, 90f)] float RotationLimitY = 80f;

    Vector2 CameraRotation = Vector2.zero;
    const string MouseX = "Mouse X"; // Strings in direct code generate garbage, storing and re-using them creates no garbage.
    const string MouseY = "Mouse Y";

    public Transform PlayerController;

    private void Start()
    {
        // Hide mouse and lock to screen center.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        CameraRotation.x += Input.GetAxis(MouseX) * MouseSensitivity;
        CameraRotation.y += Input.GetAxis(MouseY) * MouseSensitivity;
        CameraRotation.y = Mathf.Clamp(CameraRotation.y, -RotationLimitY, RotationLimitY); // (Rotation, AngleMin, AngleMax).
        
        var QuaternionX = Quaternion.AngleAxis(CameraRotation.x, Vector3.up);
        var QuaternionY = Quaternion.AngleAxis(CameraRotation.y, Vector3.left);

        transform.localRotation = QuaternionX * QuaternionY;
        transform.position = PlayerController.position + new Vector3(0, 0.75f, 0); // Insures that the camera follows the Player.
    }
}
