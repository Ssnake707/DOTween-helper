using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.TransformTweens
{
    [Serializable]
    public class TweenTransformLocalRotateQuaternion : BaseTween
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Quaternion _to;
        [SerializeField] private float _duration;

        public TweenTransformLocalRotateQuaternion(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween() =>
            _target.DOLocalRotateQuaternion(_to, _duration);
    }
}