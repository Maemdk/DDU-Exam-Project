using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelHandler))]
public class LevelHandlerEditor : Editor {
	public SerializedProperty 
		objectiveType,
		assassinationTarget;

	void OnEnable(){
		objectiveType = serializedObject.FindProperty("objectiveType");
		assassinationTarget = serializedObject.FindProperty("assassinationTarget");
	}

	public override void OnInspectorGUI(){
		serializedObject.Update();
		
		DrawDefaultInspector();

		serializedObject.ApplyModifiedProperties();
	}
}
