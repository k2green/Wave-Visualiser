using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

[CustomEditor(typeof(WaveDescriptor))]
public class WaveDescriptorEditor : Editor {

	private bool showShapeInspector = true;
	private bool showWaveInspector = true;

	public override void OnInspectorGUI() {
		DrawInspectorGUI(ref showShapeInspector, ref showWaveInspector);
	}

	public void DrawInspectorGUI(ref bool showShapeInspector, ref bool showWaveInspector) {
		var descriptor = (WaveDescriptor)this.target;

		DrawShapeFoldout(descriptor, ref showShapeInspector);
		DrawWaveFoldout(descriptor, ref showWaveInspector);
	}

	private void DrawWaveFoldout(WaveDescriptor descriptor, ref bool showWaveInspector) {
		showWaveInspector = EditorGUILayout.Foldout(showWaveInspector, "Wave Properties");

		if (showWaveInspector) {
			descriptor.WaveForm = ((WaveType)EditorGUILayout.EnumPopup("Waveform", descriptor.WaveForm.Type)).ToWaveForm();

			descriptor.Amplitude = EditorGUILayout.Slider("Amplitude", descriptor.Amplitude, .0001f, 20);
			descriptor.WaveLength = EditorGUILayout.Slider("WaveLength", descriptor.WaveLength, .1f, WaveFormBase.BaseScale);
			descriptor.TimeScale = EditorGUILayout.FloatField("Time Scale", descriptor.TimeScale);
		}
	}

	private void DrawShapeFoldout(WaveDescriptor descriptor, ref bool showShapeInspector) {
		showShapeInspector = EditorGUILayout.Foldout(showShapeInspector, "Shape Properties");

		if (showShapeInspector) {
			descriptor.WaveShape = (ShapeBase)EditorGUILayout.ObjectField("Shape", descriptor.WaveShape, typeof(ShapeBase), false);

			if (descriptor.WaveShape != null) {

				using (var changeCheck = new EditorGUI.ChangeCheckScope()) {
					var shapeEditor = CreateEditor(descriptor.WaveShape);
					shapeEditor.OnInspectorGUI();

					if (changeCheck.changed) {
						descriptor.GenerateBasePoints();
					}
				}
			}
		}
	}
}
