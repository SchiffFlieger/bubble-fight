using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaker : MonoBehaviour
{
    public AudioClip hover;
    public AudioClip click;

    public void PlayHoverSound()
    {
        AudioSource.PlayClipAtPoint(hover, transform.position);
    }
    public void PlayClickSound()
    {
        AudioSource.PlayClipAtPoint(click, transform.position);
    }
}
