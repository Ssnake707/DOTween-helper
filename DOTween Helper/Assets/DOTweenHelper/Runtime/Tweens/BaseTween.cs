using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens
{
    public abstract class BaseTween : MonoBehaviour
    {
        [SerializeField] private TweenSettings _tweenSettings;
        
        public AddTypeTween AddTypeTween => _tweenSettings.TweenAddType;

        public Tween GetTween()
        {
            Tween tween = CreateTween();
            tween.SetEase(_tweenSettings.Ease);
            tween.SetDelay(_tweenSettings.Delay, true);
            return tween;
        }

        protected abstract Tween CreateTween();
    }
}