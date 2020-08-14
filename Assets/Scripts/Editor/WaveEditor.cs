using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Wave))]
public class WaveEditor : Editor {

	private bool showShapeInspector = true;

	public override void OnInspectorGUI() {
		var wave = (Wave)target;

		DrawShapeFoldout(wave);

		base.OnInspectorGUI();
	}

	private void DrawShapeFoldout(Wave wave) {
		showShapeInspector = EditorGUILayout.Foldout(showShapeInspector, "Shape Properties");

		if (showShapeInspector) {
			wave.Shape = (ShapeBase)EditorGUILayout.ObjectField("Shape", wave.Shape, typeof(ShapeBase), false);

			if (wave.Shape != null) {

				using (var changeCheck = new EditorGUI.ChangeCheckScope()) {
					var shapeEditor = CreateEditor(wave.Shape);
					shapeEditor.OnInspectorGUI();

					if (changeCheck.changed) {
						wave.GenerateBasePoints();
					}
				}
			}
		}
	}
}
