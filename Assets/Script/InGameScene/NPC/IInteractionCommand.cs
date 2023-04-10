using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 해당 인터페이스에서는 Player의 CommandState에서 전달하는 메서드를 만든다.
// Player의 Interaction Key에 반응하는 데이터임.
namespace OneBunny
{
    public interface IInteractionCommand
    {
        public void OpenCommand() {}
    }
}