using DG.Tweening;
using TMPro;
using UnityEngine;

namespace DOTweenHelper.Runtime.Tweens.TextMeshProTween
{
    public class TweenTextMeshProColor : BaseTween
    {
        [SerializeField] private TMP_Text _target;
        [SerializeField] private Color _startColor;
        [SerializeField] private Color _endColor;
        [SerializeField] private float _duration;

        public TweenTextMeshProColor(string typeTweenName) : base(typeTweenName)
        {
        }

        protected override Tween CreateTween()
        {
            float value = 0f;
            return DOTween.To(x => value = x, 0f, 1f, _duration).OnUpdate(() =>
            {
                _target.color = Color.Lerp(_startColor, _endColor, value);
            });
        }
    }
}