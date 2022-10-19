using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    public AK.Wwise.Event sound;
    void Start()
    {
        SoundManager.instance.playSound(sound.Name, this.gameObject);
    }
}
