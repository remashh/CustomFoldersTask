using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(NoiseGenerator))]

    public class NoiseGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Save"))
            {
                var myTarget = target as NoiseGenerator;
                if (myTarget != null) myTarget.SaveTexture();
            }
        }
    }
