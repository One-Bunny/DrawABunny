using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace OneBunny
{
    public class NPCController : MonoBehaviour
    {
        [field: SerializeField] private VisibleObject visibleObject;
        [field: SerializeField] private ChatSystem chatSystem;

        
        [SerializeField] private GameObject _player = null;

        private void Awake()
        {
            if (visibleObject is null)
            {
                NPCLog($"{visibleObject.GetType()}가 존재하지 않습니다.");
            }

            if (chatSystem is null)
            {
                NPCLog($"{chatSystem.GetType()}가 존재하지 않습니다.");
            }

            if (_player is not null)
            {
                _player = null;

                visibleObject.OnSetViewer.AddListener(SetPlayer);
                visibleObject.OnClear.AddListener(ClearPlayer);
            }
        }

        private void SetPlayer(GameObject player)
        {
            _player = player;
        }

        private void ClearPlayer()
        {
            _player = null;
        }

        #region Log
        private void NPCLog(string text)
        {
            Debug.Log($"[NPC LOGGER] {GetType()} : {text}");
        }
        #endregion
    }
}