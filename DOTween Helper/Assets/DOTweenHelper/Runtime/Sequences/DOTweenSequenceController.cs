using System;
using System.Collections.Generic;
using DG.Tweening;
using DOTweenHelper.Runtime.Tweens;
using UnityEngine;

namespace DOTweenHelper.Runtime.Sequences
{
    public class DOTweenSequenceController : BaseDOTweenSequecneController
    {
        [SerializeField] private GameObject _linkGameObject;
        [SerializeField] private bool _isPlayOnAwake;
        [SerializeField] private bool _isAutoKill = false;
        [SerializeField] private SequenceLoopsSettings _sequenceLoopsSettings;
        [SerializeField] private SequenceUpdateSettings _sequenceUpdateSettings;
        [SerializeReference] private List<BaseTween> _tweens = new List<BaseTween>();

        public override event Action OnComplete;
        public override event Action OnKill;
        public override event Action OnPlay;
        public override event Action OnPause;
        public override event Action OnRewind;
        public override event Action OnStart;
        public override event Action OnStepComplete;
        public override event Action OnUpdate;
        public override bool IsPlaying => _sequence?.IsPlaying() ?? false;
        
        private Sequence _sequence = null;

        private void Awake()
        {
            if (_isPlayOnAwake)
                Play();
        }

        public override void Play()
        {
            if (_sequence == null)
            {
                CreateSequence();
                return;
            }

            _sequence.Play();
        }

        public override void Restart()
        {
            if (_sequence == null)
            {
                CreateSequence();
                return;
            }
            
            _sequence.Restart();
        }

        public override void Pause()
        {
            if (_sequence == null) return;
            _sequence.Pause();
        }

        public override void GoTo(float to, bool andPlay) => 
            _sequence.Goto(to, andPlay);

        public override void Complete(bool withCallback)
        {
            if (_sequence == null) return;
            _sequence.Complete(withCallback);
        }

        public void AddTween(BaseTween baseTween) => 
            _tweens.Add(baseTween);

        public void RegenerateSequence()
        {
            GoTo(0, false);
            CreateSequence();
        }

        private void CreateSequence()
        {
            if (_sequence != null)
            {
                _sequence.Complete(true);
                _sequence.Kill(true);
                _sequence = null;
            }
            
            _sequence = DOTween.Sequence();
            foreach (BaseTween tween in _tweens)
            {
                switch (tween.AddTypeTween)
                {
                    case AddTypeTween.Append:
                        _sequence.Append(tween.GetTween());
                        break;
                    case AddTypeTween.Join:
                        _sequence.Join(tween.GetTween());
                        break;
                }
            }
            SetSettings();
            SetEvents();
        }

        private void SetSettings()
        {
            _sequence.SetLink(_linkGameObject);
            _sequence.SetAutoKill(_isAutoKill);
            _sequence.SetLoops(_sequenceLoopsSettings.CountLoops, _sequenceLoopsSettings.LoopType);
            _sequence.SetUpdate(_sequenceUpdateSettings.UpdateType, _sequenceUpdateSettings.IgnoreTimeScale);
        }

        private void SetEvents()
        {
            _sequence.OnComplete(() => OnComplete?.Invoke());
            _sequence.OnKill(() =>
            {
                _sequence = null;
                OnKill?.Invoke();
            });
            _sequence.OnPlay(() => OnPlay?.Invoke());
            _sequence.OnPause(() => OnPause?.Invoke());
            _sequence.OnRewind(() => OnRewind?.Invoke());
            _sequence.OnStart(() => OnStart?.Invoke());
            _sequence.OnStepComplete(() => OnStepComplete?.Invoke());
            _sequence.OnUpdate(() => OnUpdate?.Invoke());
        }
    }
}