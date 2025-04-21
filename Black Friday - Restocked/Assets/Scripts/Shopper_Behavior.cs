using UnityEngine;

public class Shopper_Behavior : MonoBehaviour
{
    public AudioClip[] Shopper_FootstepSounds;   // An array of footstep sounds that will be randomly selected from.
    [Range(0, 1)] public float Shopper_FootstepVolume = 0.5f;

    private CharacterController Shopper_Controller;
    private AudioSource Shopper_AudioSource;
    private void Start()
    {
        Shopper_Controller = GetComponent<CharacterController>();
        Shopper_AudioSource = GetComponent<AudioSource>();
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (Shopper_FootstepSounds.Length > 0)
            {
                // Pick & play a random footstep sound from the array, excluding sound at index 0.
                int Index = Random.Range(1, Shopper_FootstepSounds.Length);
                Shopper_AudioSource.clip = Shopper_FootstepSounds[Index];
                AudioSource.PlayClipAtPoint(Shopper_AudioSource.clip, transform.TransformPoint(Shopper_Controller.center), Shopper_FootstepVolume);
                // Move picked sound to index 0 so it's not picked next time.
                Shopper_FootstepSounds[Index] = Shopper_FootstepSounds[0];
                Shopper_FootstepSounds[0] = Shopper_AudioSource.clip;
            }
        }
    }
}
