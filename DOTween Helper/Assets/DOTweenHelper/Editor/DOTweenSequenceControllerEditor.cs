using System;
using DOTweenHelper.Runtime.Sequences;
using DOTweenHelper.Runtime.Tweens;
using DOTweenHelper.Runtime.Tweens.TransformTweens;
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
                AddTween();
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
                case TypeTween.TransformJump:
                    tweenSequenceController.AddTween(new TweenTransformJump("Transform jump"));
                    break;
                case TypeTween.TransformLocalJump:
                    tweenSequenceController.AddTween(new TweenTransformLocalJump("Transform local jump"));
                    break;
                case TypeTween.TransformRotate:
                    tweenSequenceController.AddTween(new TweenTransformRotate("Transform rotate"));
                    break;
                case TypeTween.TransformLocalRotate:
                    tweenSequenceController.AddTween(new TweenTransformLocalRotate("Transform local rotate"));
                    break;
                case TypeTween.TransformRotateQuaternion:
                    tweenSequenceController.AddTween(new TweenTransformRotateQuaternion("Transform rotate quaternion"));
                    break;
                case TypeTween.TransformLocalRotateQuaternion:
                    tweenSequenceController.AddTween(new TweenTransformLocalRotateQuaternion("Transform local rotate quaternion"));
                    break;
                case TypeTween.TransformPunchPosition:
                    tweenSequenceController.AddTween(new TweenTransformPunchPosition("Transform punch position"));
                    break;
                case TypeTween.TransformPunchRotation:
                    tweenSequenceController.AddTween(new TweenTransformPunchRotation("Transform punch rotation"));
                    break;
                case TypeTween.TransformPunchScale:
                    tweenSequenceController.AddTween(new TweenTransformPunchScale("Transform punch scale"));
                    break;
                case TypeTween.TransformShakePosition:
                    tweenSequenceController.AddTween(new TweenTransformShakePosition("Transform shake position"));
                    break;
                case TypeTween.TransformShakeRotation:
                    tweenSequenceController.AddTween(new TweenTransformShakeRotation("Transform shake rotation"));
                    break;
                case TypeTween.TransformShakeScale:
                    tweenSequenceController.AddTween(new TweenTransformShakeScale("Transform shake scale"));
                    break;
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}