using System;
using UnityEngine;

namespace GhostHunter.Runtime.Features.Ghost
{
    public class GhostTouchInput : MonoBehaviour
    {
        public Action DownTouch;

        private void OnMouseDown() => 
            DownTouch?.Invoke();
    }
}