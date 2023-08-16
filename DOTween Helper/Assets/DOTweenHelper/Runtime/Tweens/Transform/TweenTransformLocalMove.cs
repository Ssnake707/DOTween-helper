using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.Transform
{
    public class TweenTransformLocalMove : BaseTween
    {
        [SerializeField] private UnityEngine.Transform _target;
        [SerializeField] private Vector3 _to;
        [SerializeField] private float _duration;
        protected override Tween CreateTween() => 
            _target.DOLocalMove(_to, _duration);
    }
}