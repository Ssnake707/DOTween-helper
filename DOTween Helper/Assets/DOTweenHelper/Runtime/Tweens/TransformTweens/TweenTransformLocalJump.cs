using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.TransformTweens
{
    [Serializable]
    public class TweenTransformLocalJump : BaseTween
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _to;
        [SerializeField] private float _jumpPower;
        [SerializeField] private int _countJump;
        [SerializeField] private float _duration;
        public TweenTransformLocalJump(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween() => 
            _target.DOLocalJump(_to, _jumpPower, _countJump, _duration);
    }
}