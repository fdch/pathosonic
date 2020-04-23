using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDN_FadeVolume : MonoBehaviour
{
    [SerializeField] private AudioSource NarrationSource;
    [SerializeField] private AudioSource BackgroundSource;

    public float BackgroundVolume;

    private void Update()
    {
        BackgroundVolume = BackgroundSource.volume;

        if (NarrationSource.isPlaying)
            {
                if (BackgroundSource.volume > 0.2f)
                {
                    BackgroundSource.volume -= BackgroundVolume * Time.deltaTime / 0.5f;
                }
            }

         else
                if (BackgroundSource.volume < 0.5f)
            {
                BackgroundSource.volume += BackgroundVolume * Time.deltaTime / 0.5f;
            }
        }
}
