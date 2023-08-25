using System;

namespace DOTweenHelper.Runtime.Sequences
{
    public interface IDOTweenAnimationController
    {
        event Action OnComplete;
        event Action OnKill;
        event Action OnPlay;
        event Action OnPause;
        event Action OnRewind;
        event Action OnStart;
        event Action OnStepComplete;
        event Action OnUpdate;
        bool IsPlaying { get; }
        void Play();
        void Pause();
        void GoTo(float to, bool andPlay);
        void Complete(bool withCallback);
        void Restart();
    }
}