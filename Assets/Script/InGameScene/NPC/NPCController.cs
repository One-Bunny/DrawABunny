using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneBunny
{
    public class NPCController : MonoBehaviour, IInteractionAction
    {
        [field: SerializeField] private VisibleObject visibleObject;
        [field: SerializeField] private ChatSystem chatSystem;

        
        [SerializeField] private GameObject _target = null;

        [SerializeField] private InteractionInformation interactInfo;

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

            if (_target is not null)
            {
                _target = null;

                visibleObject.OnSetViewer.AddListener(SetTarget);
                visibleObject.OnClear.AddListener(ClearTarget);
            }
        }

        private void SetTarget(GameObject target)
        {
            _target = target;
        }

        private void ClearTarget()
        {
            _target = null;
        }

        #region Log
        private void NPCLog(string text)
        {
            Debug.Log($"[NPC LOGGER] {GetType()} : {text}");
        }
        #endregion
    }
}