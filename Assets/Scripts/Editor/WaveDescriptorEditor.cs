using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

[CustomEditor(typeof(WaveDescriptor))]
public class WaveDescriptorEditor : Editor {

	private bool showWaveInspector = true;

	public override void OnInspectorGUI() {
		var descriptor = (WaveDescriptor)this.target;

		DrawWaveFoldout(descriptor);
	}

	private void DrawWaveFoldout(WaveDescriptor descriptor) {
		showWaveInspector = EditorGUILayout.Foldout(showWaveInspector, "Wave Properties");

		if (showWaveInspector) {
			descriptor.WaveForm = ((WaveType)EditorGUILayout.EnumPopup("Waveform", descriptor.WaveForm.Type)).ToWaveForm();

			descriptor.Amplitude = EditorGUILayout.Slider("Amplitude", descriptor.Amplitude, .0001f, 20);
			descriptor.WaveLength = EditorGUILayout.Slider("WaveLength", descriptor.WaveLength, .1f, WaveFormBase.BaseScale);
			descriptor.TimeScale = EditorGUILayout.FloatField("Time Scale", descriptor.TimeScale);
		}
	}
}
