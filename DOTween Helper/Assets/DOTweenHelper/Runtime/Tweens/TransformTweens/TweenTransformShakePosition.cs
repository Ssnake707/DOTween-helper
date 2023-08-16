using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.TransformTweens
{
    [Serializable]
    public class TweenTransformShakePosition : BaseTween
    {
        [SerializeField] private Transform _target;
        [SerializeField] private bool _useVectorStrength;
        [SerializeField] private Vector3 _strength;
        [SerializeField] private float _strengthFloat = 1f;
        [SerializeField] private float _duration;
        [SerializeField] private int _vibrato = 10;
        [SerializeField] private float _randomness = 90f;
        [SerializeField] private ShakeRandomnessMode _randomnessMode = ShakeRandomnessMode.Full;
        [SerializeField] private bool _fadeOut = true;

        public TweenTransformShakePosition(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween() =>
            _useVectorStrength
                ? _target.DOShakePosition(_duration, _strength, _vibrato, _randomness, false, _fadeOut,
                    _randomnessMode)
                : _target.DOShakePosition(_duration, _strengthFloat, _vibrato, _randomness, false, _fadeOut,
                    _randomnessMode);
    }
}