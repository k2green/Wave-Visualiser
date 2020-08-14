﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveDescription", menuName = "Wave Description")]
public class WaveDescriptor : ScriptableObject {

	public WaveFormBase WaveForm { get; set; } = new SineWave();

	public float Amplitude { get; set; }
	public float WaveLength { get; set; }
	public float TimeScale { get; set; }

	public Vector3[] BasePoints { get; private set; }

	public float GetOffset(float positionPercent) => WaveForm.GetOffset(positionPercent, WaveLength, Amplitude, Time.time * TimeScale % (2 * Mathf.PI));
	public float GetUnitOffset(float positionPercent) => WaveForm.GetOffset(positionPercent, WaveLength, 1, Time.time * TimeScale % (2 * Mathf.PI));
}
