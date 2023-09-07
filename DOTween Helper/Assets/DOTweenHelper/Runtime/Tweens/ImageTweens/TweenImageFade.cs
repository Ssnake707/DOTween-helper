using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DOTweenHelper.Runtime.Tweens.ImageTweens
{
    [Serializable]
    public class TweenImageFade : BaseTween
    {
        [SerializeField] private Image _target;
        [SerializeField] private float _duration;
        public TweenImageFade(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween()
        {
            return null;
        }
    }
}