using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundComp 
{
    [SerializeField]
    private string soundName;
    [SerializeField]
    GameObject parent;
    public bool playOnStart = false;

    AK.Wwise.Switch curSwitch;

    public void PlaySound(GameObject go)
    {
        parent = go;
        if(curSwitch != null)
        {
            AkSoundEngine.SetSwitch(curSwitch.GroupId, curSwitch.Id, parent);
        }
        AkSoundEngine.PostEvent(soundName, parent);
    }

    public string getName()
    {
        return soundName;
    }

    public void setParent(GameObject p)
    {
        parent = p;
        
    }

    public GameObject getParent()
    {
        return parent;
    }
    public void initializeSound(string name)
    {
        soundName = name;
    }


    public void setSwitch(AK.Wwise.Switch wwiseSwitch)
    {
        curSwitch = wwiseSwitch;
    }
}
