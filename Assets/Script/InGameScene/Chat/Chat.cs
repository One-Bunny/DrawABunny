using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{
    // Data -> ScriptableObject
    
    // 현재 Chat이 완료되었는지? -> IS Done
    public bool IsDone()
    {
        return DoneCheck();
    }

    private bool DoneCheck()
    {
        return true;
    }
    
    // 현재 Chat이 진행중인지? -> IS Playing
    public bool IsPlaying()
    {
        return false;
    }
    
    // Chat을 출력하는 것. -> Typing Effect
    public string Print()
    {
        // While
        return "TEST";
    }
}
