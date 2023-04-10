using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// 해당 Script를 붙일 경우, 주어진 조건에 맞는 Signal Radius가 생긴다.
// OnCatch Event를 통해서 Data에 접근할 수 있다.
namespace OneBunny
{
    public class CommandSignals : MonoBehaviour
    {
        public UnityEvent<bool> OnCatch;
        
        private void FixedUpdate()
        {
        }
        
        public void SetSignal()
        {
            
        }

        public void GetSignalRadius()
        {
            
        }

        private void ShootRay()
        {
            
        }
        
        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            // Gizmo를 통해서 Ray를 발사한다. 해당 Ray 만큼의 거리를 갈 수 있다.
        }
        #endif
    }
}