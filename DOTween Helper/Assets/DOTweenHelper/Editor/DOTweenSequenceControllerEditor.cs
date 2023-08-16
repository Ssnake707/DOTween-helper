using System;
using DOTweenHelper.Runtime.Sequences;
using DOTweenHelper.Runtime.Tweens;
using DOTweenHelper.Runtime.Tweens.TransformTweens;
using UnityEditor;
using UnityEngine;

namespace DOTweenHelper.Editor
{
    [CustomEditor(typeof(DOTweenSequenceController))]
    public class DOTweenSequenceControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CreateButtonAddElementToList();
        }

        private void CreateButtonAddElementToList()
        {
            if (GUILayout.Button("Add tween"))
            {
                GenericMenu menu = new GenericMenu();
                foreach (TypeTween typeTween in Enum.GetValues(typeof(TypeTween)))
                    AddMenuItem(menu, typeTween.ToString(), typeTween);
                
                menu.ShowAsContext();
            }
        }
        
        private void AddMenuItem(GenericMenu menu, string menuPath, TypeTween typeTween)
        {
            menuPath = menuPath.Replace("_", " ");
            int indexFirstSpace = menuPath.IndexOf(" ", StringComparison.Ordinal);
            string root = menuPath.Substring(0, indexFirstSpace);
            menuPath = menuPath.Remove(0, indexFirstSpace);
            menu.AddItem(new GUIContent($"{root}/{menuPath}"), false, OnSelected, typeTween);
        }

        private void OnSelected(object typeTween)
        {
            //_typeTween = (TypeTween)typeTween;
            AddTween((TypeTween)typeTween);
        }

        private void AddTween(TypeTween typeTween)
        {
            serializedObject.Update();
            DOTweenSequenceController tweenSequenceController = (DOTweenSequenceController)target;
            switch (typeTween)
            {
                case TypeTween.Transform_Local_Move:
                    tweenSequenceController.AddTween(new TweenTransformLocalMove("Transform local move"));
                    break;
                case TypeTween.Transform_Move:
                    tweenSequenceController.AddTween(new TweenTransformMove("Transform move"));
                    break;
                case TypeTween.Transform_Scale:
                    tweenSequenceController.AddTween(new TweenTransformScale("Transform scale"));
                    break;
                case TypeTween.Transform_Jump:
                    tweenSequenceController.AddTween(new TweenTransformJump("Transform jump"));
                    break;
                case TypeTween.Transform_Local_Jump:
                    tweenSequenceController.AddTween(new TweenTransformLocalJump("Transform local jump"));
                    break;
                case TypeTween.Transform_Rotate:
                    tweenSequenceController.AddTween(new TweenTransformRotate("Transform rotate"));
                    break;
                case TypeTween.Transform_Local_Rotate:
                    tweenSequenceController.AddTween(new TweenTransformLocalRotate("Transform local rotate"));
                    break;
                case TypeTween.Transform_Rotate_Quaternion:
                    tweenSequenceController.AddTween(new TweenTransformRotateQuaternion("Transform rotate quaternion"));
                    break;
                case TypeTween.Transform_Local_Rotate_Quaternion:
                    tweenSequenceController.AddTween(new TweenTransformLocalRotateQuaternion("Transform local rotate quaternion"));
                    break;
                case TypeTween.Transform_Punch_Position:
                    tweenSequenceController.AddTween(new TweenTransformPunchPosition("Transform punch position"));
                    break;
                case TypeTween.Transform_Punch_Rotation:
                    tweenSequenceController.AddTween(new TweenTransformPunchRotation("Transform punch rotation"));
                    break;
                case TypeTween.Transform_Punch_Scale:
                    tweenSequenceController.AddTween(new TweenTransformPunchScale("Transform punch scale"));
                    break;
                case TypeTween.Transform_Shake_Position:
                    tweenSequenceController.AddTween(new TweenTransformShakePosition("Transform shake position"));
                    break;
                case TypeTween.Transform_Shake_Rotation:
                    tweenSequenceController.AddTween(new TweenTransformShakeRotation("Transform shake rotation"));
                    break;
                case TypeTween.Transform_Shake_Scale:
                    tweenSequenceController.AddTween(new TweenTransformShakeScale("Transform shake scale"));
                    break;
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}