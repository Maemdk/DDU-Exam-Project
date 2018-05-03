using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelHandler))]
public class LevelHandlerEditor : Editor {
	public SerializedProperty 
		objectiveType_prop,
		assassinationTarget_prop,
		targetLight_prop,
		targetLightHeight_prop;

	void OnEnable(){
		objectiveType_prop = serializedObject.FindProperty("objectiveType");
		assassinationTarget_prop = serializedObject.FindProperty("assassinationTarget");
		targetLight_prop = serializedObject.FindProperty("targetLight");
		targetLightHeight_prop = serializedObject.FindProperty("targetLightHeight");
	}

	public override void OnInspectorGUI(){
		serializedObject.Update();

		DrawDefaultInspector();

		serializedObject.ApplyModifiedProperties();
	}
}
