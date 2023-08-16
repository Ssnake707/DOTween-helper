using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.TransformTweens
{
    [Serializable]
    public class TweenTransformRotateQuaternion : BaseTween
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Quaternion _to;
        [SerializeField] private float _duration;

        public TweenTransformRotateQuaternion(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween() =>
            _target.DORotateQuaternion(_to, _duration);
    }
}