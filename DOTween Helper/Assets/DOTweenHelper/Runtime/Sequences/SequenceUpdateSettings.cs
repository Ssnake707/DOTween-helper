using System;
using DG.Tweening;

namespace DOTweenHelper.Runtime.Sequences
{
    [Serializable]
    public class SequenceUpdateSettings
    {
        public UpdateType UpdateType;
        public bool IgnoreTimeScale;
    }
}