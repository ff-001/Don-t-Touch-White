using UnityEditor;
using UnityEngine;

//修改 Transform
[CustomEditor(typeof(Transform))]

[ExecuteInEditMode]

public class transformEditor : Editor {

	public override void OnInspectorGUI() {

		Transform trans = (Transform) target;

//		GUILayout.BeginHorizontal();
//		{
//			bool reset = GUILayout.Button("P", GUILayout.Width(20f));
//			
//			EditorGUILayout.PropertyField(trans.position.x);
//			EditorGUILayout.PropertyField(trans.position.y);
//			EditorGUILayout.PropertyField(trans.position.z);
//			
//			if (reset) trans.position = Vector3.zero;
//		}
//		GUILayout.EndHorizontal();
		//Position
		EditorGUILayout.BeginHorizontal();
		{
			if (DrawButton("P")) {
				trans.localPosition = Vector3.zero;
			}
			trans.localPosition = EditorGUILayout.Vector3Field("位置",trans.localPosition);
		}
		EditorGUILayout.EndHorizontal();
		
		//Rotation
		EditorGUILayout.BeginHorizontal();
		{
			if (DrawButton("R")) {
				trans.localEulerAngles = Vector3.zero;
			}
			trans.localEulerAngles = EditorGUILayout.Vector3Field("旋转",trans.localEulerAngles);
		}
		EditorGUILayout.EndHorizontal();
	
		//Scale
		EditorGUILayout.BeginHorizontal();
		{
			if (DrawButton("S")) {
				trans.localScale = Vector3.one;
			}
			trans.localScale = EditorGUILayout.Vector3Field("缩放",trans.localScale);
		}
		EditorGUILayout.EndHorizontal();
	}
	
	static bool DrawButton (string title) {
		return GUILayout.Button(title, GUILayout.Width(20f),GUILayout.Height(20f));
	}
}