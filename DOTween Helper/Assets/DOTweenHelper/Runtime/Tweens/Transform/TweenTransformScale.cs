using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.Transform
{
    [Serializable]
    public class TweenTransformScale : BaseTween
    {
        [SerializeField] private UnityEngine.Transform _target;
        [SerializeField] private Vector3 _to;
        [SerializeField] private float _duration;

        public TweenTransformScale(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween() =>
            _target.DOScale(_to, _duration);
    }
}