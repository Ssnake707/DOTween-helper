using DOTweenHelper.Runtime.Sequences;
using DOTweenHelper.Runtime.Tweens;
using DOTweenHelper.Runtime.Tweens.Transform;
using UnityEditor;
using UnityEngine;

namespace DOTweenHelper.Editor
{
    [UnityEditor.CustomEditor(typeof(DOTweenSequenceController))]
    public class DOTweenSequenceControllerEditor : UnityEditor.Editor
    {
        private TypeTween _typeTween;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CreateButtonAddElementToList();
        }

        private void CreateButtonAddElementToList()
        {
            _typeTween = (TypeTween)EditorGUILayout.EnumPopup("Tween type:", _typeTween);
            if (GUILayout.Button("Add tween"))
            {
                AddTween();
            }
        }

        private void AddTween()
        {
            serializedObject.Update();
            DOTweenSequenceController tweenSequenceController = (DOTweenSequenceController)target;
            switch (_typeTween)
            {
                case TypeTween.TransformLocalMove:
                    tweenSequenceController.AddTween(new TweenTransformLocalMove("Transform local move"));
                    break;
                case TypeTween.TransformMove:
                    tweenSequenceController.AddTween(new TweenTransformMove("Transform move"));
                    break;
                case TypeTween.TransformScale:
                    tweenSequenceController.AddTween(new TweenTransformScale("Transform scale"));
                    break;
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}