using System;
using DG.Tweening;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens
{
    [Serializable]
    public abstract class BaseTween
    {
        [HideInInspector] public string TypeTweenName;
        [SerializeField] private TweenSettings _tweenSettings;
        
        public AddTypeTween AddTypeTween => _tweenSettings.TweenAddType;

        protected BaseTween(string typeTweenName) => 
            TypeTweenName = typeTweenName;

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