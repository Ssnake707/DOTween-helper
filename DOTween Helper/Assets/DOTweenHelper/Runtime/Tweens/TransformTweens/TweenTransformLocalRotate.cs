using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.TransformTweens
{
    [Serializable]
    public class TweenTransformLocalRotate : BaseTween
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _to;
        [SerializeField] private RotateMode _rotateMode = RotateMode.Fast;
        [SerializeField] private float _duration;

        public TweenTransformLocalRotate(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween() =>
            _target.DOLocalRotate(_to, _duration, _rotateMode);
    }
}