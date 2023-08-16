using System;
using DOTweenHelper.Runtime.Sequences;
using DOTweenHelper.Runtime.Tweens;
using DOTweenHelper.Runtime.Tweens.TextMeshProTween;
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
            CreateDebugPanel();
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

        private void OnSelected(object typeTween) => 
            AddTween((TypeTween)typeTween);

        private void CreateDebugPanel()
        {
            GUILayout.Space(10f);
            GUILayout.BeginVertical("GroupBox");
            GUILayout.Space(5f);
            
            CreateButtonPlay();
            GUILayout.Space(5f);
            CreateButtonCreateSequence();
            GUILayout.Space(5f);
            
            GUILayout.EndVertical();
        }

        private void CreateButtonPlay()
        {
            GUI.enabled = Application.isPlaying;

            GUIStyle guiStyle = new GUIStyle(GUI.skin.button);
            guiStyle.fontSize = 15;
            if (GUILayout.Button("Play", guiStyle))
            {
                DOTweenSequenceController tweenSequenceController = (DOTweenSequenceController)target;
                tweenSequenceController.Play();
            }
            
            GUI.enabled = true;
        }

        private void CreateButtonCreateSequence()
        {
            GUI.enabled = Application.isPlaying;
            GUIStyle guiStyle = new GUIStyle(GUI.skin.button);
            guiStyle.fontSize = 15;
            if (GUILayout.Button("Regenerate sequence", guiStyle))
            {
                DOTweenSequenceController tweenSequenceController = (DOTweenSequenceController)target;
                tweenSequenceController.RegenerateSequence();
            }

            GUI.enabled = true;
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
                case TypeTween.TextMeshPro_Color:
                    tweenSequenceController.AddTween(new TweenTextMeshProColor("TextMeshPro colo"));
                    break;
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}