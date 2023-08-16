using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.TransformTweens
{
    [Serializable]
    public class TweenTransformPunchPosition : BaseTween
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _punch;
        [SerializeField] private int _vibrato = 10;
        [SerializeField] private float _elasticity = 1f;
        [SerializeField] private float _duration;

        public TweenTransformPunchPosition(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween() =>
            _target.DOPunchPosition(_punch, _duration, _vibrato, _elasticity);
    }
}