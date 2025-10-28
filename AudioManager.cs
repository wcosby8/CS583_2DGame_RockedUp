using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip jump;
    public AudioClip land;
    public AudioClip death;
    public AudioClip hitByRock;

    public void PlaySFX( AudioClip clip ){
        SFXSource.PlayOneShot(clip);
    }
}

