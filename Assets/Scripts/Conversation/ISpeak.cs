using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SpeakInfo
{
    public GameEntity speaker;
    public string words;
}

public interface ISpeak
{
    public void speak(SpeakInfo speakInfo);
}
