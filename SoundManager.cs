using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SoundManager : MonoBehaviour 
{
    public static SoundManager instance;

    public List <SoundComp> sounds = new List <SoundComp>();

    [SerializeField] private GameObject standardLocation;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        foreach (SoundComp _sound in sounds)
        {
            if (_sound.playOnStart) _sound.PlaySound(standardLocation);
        }
        
    }

    public void playSound(string name) => GetSound(name)?.PlaySound(standardLocation);

    public void playSound(string name, GameObject go) => GetSound(name)?.PlaySound(go);

    public void playSound(AK.Wwise.Event sound) => GetSound(sound.Name)?.PlaySound(standardLocation);

    public void playSound(AK.Wwise.Event sound, GameObject go) => GetSound(sound.Name)?.PlaySound(go);
    public void addSound(string name)
    {
        SoundComp tempSound = new SoundComp();
        sounds.Add(tempSound);
        tempSound.initializeSound(name);
    }

    private SoundComp GetSound(string name)
    {
        if(!(name == "None"))
        {
            foreach (SoundComp sound in instance.sounds)                //Check if it already exists
            {
                if(sound.getName() == name)
                {
                    return sound;
                }
            }
            string[] names = new string[1];                            //If it doesnt, make it
            names[0] = name;
            AKRESULT eResult = AkSoundEngine.PrepareEvent(AkPreparationType.Preparation_Load, names, 1);    //Check if wwise knows the event
            if (eResult == AKRESULT.AK_Success){
                SoundComp soundComp = new SoundComp();
                soundComp.initializeSound(name);
                addSound(name);
                return soundComp;
             } else{                                                   //If it doesnt, give us a message showing what the wrong one is
                Debug.Log(name + eResult);
             }
        }
        return null;
    }

    public void setState(AK.Wwise.State s)
    {
        AkSoundEngine.SetState(s.GroupId, s.Id);
    }

    public void setSwitch(AK.Wwise.Switch wwiseSwitch,  GameObject go)
    {
        foreach (var item in sounds)
        {
            if(item.getParent() == go)
            {
                item.setSwitch(wwiseSwitch);
            }
        }
    }


    public void setGlobalRTPC(AK.Wwise.RTPC wwiseRTPC, float RTPCValue)
    {
        wwiseRTPC.SetGlobalValue(RTPCValue);
    }

    public void setRTPC(AK.Wwise.RTPC wwiseRTPC, float RTPCValue, GameObject go)
    {
        wwiseRTPC.SetValue(go, RTPCValue);
    }
}
