using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OneBunny
{
    public class NPCController : MonoBehaviour, IVIsibleObject, IInteractionAction
    {
        [field: SerializeField] public GameObject _textUI;

        private void Awake()
        {
            if(_textUI == null)
            {
                Debug.Log($"{_textUI.GetType()}이 존재하지 않습니다.");
            }
        }

        private void OnText(bool isOn)
        {
            _textUI.SetActive(isOn);
        }


        #region Interface

        public void OnObject(bool isOn)
        {
            OnText(isOn);
        }

        public void GetAction()
        {
            // Get Action을 통해서
            // Player <-> NPC 간 대화라던지, Action 행위 지정.

            // Player에서 E Key에 GetAction Bind를 지정.
        }


        #endregion
    }
}