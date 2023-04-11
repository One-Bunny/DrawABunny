using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace OneBunny
{
    public class VisibleObject : MonoBehaviour, IVisibleObject
    {
        [field: SerializeField] public GameObject visibleObject { get; private set; }
        private GameObject viewerObject = null;

        [HideInInspector] public UnityEvent<GameObject> OnSetViewer;
        [HideInInspector] public UnityEvent OnClear;


        public void SetViewer(GameObject viewer)
        {
            if (viewer is not null)
            {
                viewerObject = viewer;
                
                OnSetViewer?.Invoke(viewerObject);
            }
        }

        public void ClearViewer()
        {
            viewerObject = null;
            OnClear?.Invoke();
        }
            
        #region Interface
        
        public void OnObject(bool isOn)
        {
            visibleObject.SetActive(isOn);
        }
        
        #endregion

    }
}