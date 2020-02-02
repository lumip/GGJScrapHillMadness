using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] clipArray;
    public AudioSource effectSource;
    public float pitchMin, pitchMax, volumeMin, volumeMax;
    private int clipIndex;
    // Start is called before the first frame update

    void PlayRoundRobin()
    {
        effectSource.pitch = Random.Range(pitchMin, pitchMax);
        effectSource.volume = Random.Range(volumeMin, volumeMax);
        if (clipIndex < clipArray.Length)
        {
            effectSource.PlayOneShot(clipArray[clipIndex]);
            clipIndex++;
        }

        else
        {
            clipIndex = 0;
            effectSource.PlayOneShot(clipArray[clipIndex]);
            clipIndex++;
        }
    }
    void PlayRandom()
    {
        effectSource.pitch = Random.Range(pitchMin, pitchMax);
        effectSource.volume = Random.Range(volumeMin, volumeMax);
        clipIndex = Random.Range(0, clipArray.Length);
        effectSource.PlayOneShot(clipArray[clipIndex]);
    }
    int RepeatCheck(int previousIndex, int range)
    {
        int index = Random.Range(0, range);

        while (index == previousIndex)
        {
            index = Random.Range(0, range);
        }
        return index;
    }
    void PlayRandom2()
    {
        clipIndex = RepeatCheck(clipIndex, clipArray.Length);
        effectSource.PlayOneShot(clipArray[clipIndex]);
    }
    void Update()
    {
        if(!effectSource.isPlaying)
            {
                PlayRoundRobin();
        }
    }
}
