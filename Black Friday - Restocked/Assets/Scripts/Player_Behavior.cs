using UnityEngine;

public class Player_Behavior : MonoBehaviour
{
    [Header("Speed"), Space(10)]
    public float Speed_Movement = 5;
    public float Speed_Rotation = 50;

    private CharacterController Player_Controller;
    private AudioSource Player_AudioSource;

    private void Start()
    {
        Player_Controller = GetComponent<CharacterController>();
        Player_AudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 Movement = transform.forward * Input.GetAxisRaw("Vertical");
        if (Movement.sqrMagnitude > 1) Movement.Normalize(); // Normalize PlayerMovement if it has a magnitude > 1 to prevent faster diagonal movement.
        Player_Controller.Move(Movement * Speed_Movement * Time.deltaTime);

        if (IsPlayerMoving())
        {
            if (!Player_AudioSource.isPlaying) Player_AudioSource.Play();
        }
        else
        {
            if (Player_AudioSource.isPlaying) Player_AudioSource.Pause();
        }
    }

    private void LateUpdate() // Do rotation in LateUpdate, or you will get stuttering.
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(-Vector3.up * Speed_Rotation * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) transform.Rotate(Vector3.up * Speed_Rotation * Time.deltaTime);
    }
    private bool IsPlayerMoving()
    {
        return Player_Controller.velocity != Vector3.zero; // Check if the Player's velocity is not zero.
    }
}
