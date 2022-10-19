using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StringEvent{
    public string name;
    public AK.Wwise.Event eventName;
}

[CreateAssetMenu(menuName = "AudioData/Character", fileName = "New Player Audio Data")]
public class CharacterAudioData : ScriptableObject
{
    public List <StringEvent> events = new List <StringEvent>();

    public AK.Wwise.Event GetEventByName(string n)
    {
        foreach (var item in events)
        {
            if(item.name == n)
            {
                return item.eventName;
            }
        }
        Debug.Log(n + " was called but doesnt exist");
        return null;
    }
}
