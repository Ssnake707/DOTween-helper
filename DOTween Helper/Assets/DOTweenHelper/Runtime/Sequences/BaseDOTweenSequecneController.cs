using System;
using UnityEngine;

namespace DOTweenHelper.Runtime.Sequences
{
    public abstract class BaseDOTweenSequecneController : MonoBehaviour, IDOTweenAnimationController
    {
        public abstract event Action OnComplete;
        public abstract event Action OnKill;
        public abstract event Action OnPlay;
        public abstract event Action OnPause;
        public abstract event Action OnRewind;
        public abstract event Action OnStart;
        public abstract event Action OnStepComplete;
        public abstract event Action OnUpdate;
        
        public abstract bool IsPlaying { get; }
        public abstract void Play();
        public abstract void Pause();
        public abstract void GoTo(float to, bool andPlay);
        public abstract void Complete(bool withCallback);
        public abstract void Restart();
    }
}