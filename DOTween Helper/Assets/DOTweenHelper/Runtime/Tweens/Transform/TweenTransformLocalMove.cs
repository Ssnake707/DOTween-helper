using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.Transform
{
    [Serializable]
    public class TweenTransformLocalMove : BaseTween
    {
        [SerializeField] private UnityEngine.Transform _target;
        [SerializeField] private Vector3 _to;
        [SerializeField] private float _duration;

        public TweenTransformLocalMove(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween() => 
            _target.DOLocalMove(_to, _duration);
    }
}