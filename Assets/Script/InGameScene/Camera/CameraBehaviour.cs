using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace OneBunny
{
    public class CameraBehaviour : MonoBehaviour
    {
        [field: SerializeField] public CinemachineVirtualCamera VirtualCamera { get; private set; }


        public void SetFollower(Transform point)
        {
            VirtualCamera.Follow = point;
        }
    }
}