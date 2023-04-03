using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using System.Linq;

namespace OneBunny
{
    [CustomEditor(typeof(FSMRunner<>), true)]
    public class FSMRunnerViewer : Editor
    {
        private Type targetType = null;

        private int statePopupIndex = 0;
        private string currentStateName = "";


        protected void OnEnable()
        {
            SceneView.duringSceneGui += this.OnSceneGUI;

            targetType = target.GetType();
            while (targetType.BaseType != typeof(MonoBehaviour))
            {
                targetType = targetType.BaseType;
            }
        }

        protected void OnDisable()
        {
            SceneView.duringSceneGui -= this.OnSceneGUI;
        }

        public override void OnInspectorGUI()
        {
            ShowStateInfo();

            EditorGUILayout.Space(10f);

            base.OnInspectorGUI();
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            var transform = ((MonoBehaviour)target).transform;
            Handles.Label(transform.position + Vector3.up, currentStateName);
        }


        private void ShowStateInfo()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            currentStateName = GetTypeName(GetValue("_currentState"));
            var previousStateName = GetTypeName(GetValue("_previousState"));

            var ids = new List<int>();
            var names = new List<string>();

            SetStateList((dynamic)GetValue("_states"), ids, names, currentStateName);

            GUILayout.Label("State Status", EditorStyles.boldLabel, GUILayout.Width(100));

            EditorGUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.Height(27));

            EditorGUILayout.BeginHorizontal();

            GUILayout.Label("PreviousState : ", EditorStyles.whiteLargeLabel, GUILayout.Width(100));
            GUILayout.Label($"{previousStateName}", EditorStyles.largeLabel, GUILayout.ExpandWidth(false));


            GUILayout.Label("➜", EditorStyles.whiteLargeLabel, GUILayout.Width(20));

            GUILayout.Label("CurrentState : ", EditorStyles.whiteLargeLabel, GUILayout.Width(100));
            GUILayout.Label($"{currentStateName}", EditorStyles.largeLabel, GUILayout.ExpandWidth(false));

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        private object GetValue(string fieldName)
        {
            return targetType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default)?.GetValue(target);
        }

        private string GetTypeName(object type)
        {
            return type?.ToString()?.Split('.')[^1] ?? "None";
        }

        private void SetStateList<T>(Dictionary<int, T> states, List<int> ids, List<string> names, string currentStateName)
        {
            var keys = states.Keys.ToList();
            var values = states.Values.ToList();

            for (int i = 0; i < states.Count; i++)
            {
                var name = GetTypeName(values[i]);
                names.Add(name);
                ids.Add(keys[i]);

                if (name == currentStateName)
                {
                    statePopupIndex = i;
                }
            }
        }
    }
}
