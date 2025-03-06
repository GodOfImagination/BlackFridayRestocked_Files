using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 0f;
    public float TurningSpeed = 0f;

    private CharacterController Controller;

    private void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    private void LateUpdate() // Do rotation in LateUpdate, or you will get stuttering.
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(-Vector3.up * TurningSpeed);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) transform.Rotate(Vector3.up * TurningSpeed);
    }

    private void Movement()
    {
        float AxisX = Input.GetAxisRaw("Horizontal");
        float AxisZ = Input.GetAxisRaw("Vertical");

        Vector3 Move = transform.right * AxisX + transform.forward * AxisZ;

        if (Move.sqrMagnitude > 1) Move.Normalize(); // Normalize PlayerMovement if it has a magnitude > 1 to prevent faster diagonal movement.

        Controller.Move(Move * MovementSpeed * Time.deltaTime);
    }
}
