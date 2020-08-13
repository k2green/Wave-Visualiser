using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

[CustomEditor(typeof(WaveDescriptor))]
public class WaveDescriptorEditor : Editor {

	private bool showShapeInspector = true;

	public override void OnInspectorGUI() {
		var descriptor = (WaveDescriptor)this.target;

		showShapeInspector = EditorGUILayout.Foldout(showShapeInspector, "Shape Properties");

		if (showShapeInspector) {
			descriptor.WaveShape = (ShapeBase)EditorGUILayout.ObjectField("Shape", descriptor.WaveShape, typeof(ShapeBase), false);

			if (descriptor.WaveShape != null) {

				using (var changeCheck = new EditorGUI.ChangeCheckScope()) {
					var shapeEditor = CreateEditor(descriptor.WaveShape);
					shapeEditor.OnInspectorGUI();

					if(changeCheck.changed) {
						descriptor.GenerateBasePoints();
					}
				}
			}
		}

		descriptor.WaveForm = ((WaveType)EditorGUILayout.EnumPopup("Waveform", descriptor.WaveForm.Type)).ToWaveForm();
	}
}
