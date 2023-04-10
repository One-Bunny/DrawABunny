using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneBunny
{
    public class NPCController : MonoBehaviour, IInteractionCommand
    {
        // NPC는 Idle 상태의 Animation만 가지고 있음.
        // NPC는 일정 시간이 지나면 Free Text를 펼침
        // NPC에게 가까이 다가가면 상호작용 Key를 나타남 <-> 멀어지면 Key가 사라짐 -> 이건 CommandSignal에서 데이터 가져오자.
        // 상호작용으로 대화를 할 수 있음. <-> 다른 행동도 가능할 수 있음.

        // NPC Interaction이 보이는 Radius
        private float _searchRadius = .0f;

        // NPC의 Default 상태가 보일 때
        private float _printTextTime = .0f;
        
        [field:SerializeField] public CommandSignals Signals { get; private set; }

        private void Awake()
        {
            // Signal을 설정한다.
            Signals.SetSignal();
        }

        
        #region InterfaceMethod
        
        // Interace -> Player Get Method. 
        public void OpenCommand()
        {
            
        }
        
        #endregion
    }
}