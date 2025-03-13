using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    [Header("Speed"), Space(10)]
    public float SpeedMovement = 5;
    public float SpeedRotation = 50;

    private CharacterController CharacterController;
    private AudioSource AudioSource;

    private void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 Movement = transform.forward * Input.GetAxisRaw("Vertical");
        if (Movement.sqrMagnitude > 1) Movement.Normalize(); // Normalize PlayerMovement if it has a magnitude > 1 to prevent faster diagonal movement.
        CharacterController.Move(Movement * SpeedMovement * Time.deltaTime);

        if (IsPlayerMoving())
        {
            if (!AudioSource.isPlaying) AudioSource.Play();
        }
        else
        {
            if (AudioSource.isPlaying) AudioSource.Pause();
        }
    }

    private void LateUpdate() // Do rotation in LateUpdate, or you will get stuttering.
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(-Vector3.up * SpeedRotation * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) transform.Rotate(Vector3.up * SpeedRotation * Time.deltaTime);
    }
    private bool IsPlayerMoving()
    {
        return CharacterController.velocity != Vector3.zero; // Check if the Player's velocity is not zero.
    }
}
