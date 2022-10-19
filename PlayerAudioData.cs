using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioData/Player", fileName = "New Player Audio Data")]
public class PlayerAudioData : ScriptableObject
{
    public AK.Wwise.Event Footsteps;
    public AK.Wwise.Event Attack;
    public AK.Wwise.Event Hit;
}
