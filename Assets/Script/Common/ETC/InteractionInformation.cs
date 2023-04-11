using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionInformation
{
    // 상호작용 타입
    public InteractionType infoType;
    
    public InteractionInformation() {}
}

public enum InteractionType
{
    Start,
    
    Chat,
    
    End
}