using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawtoothWave : WaveFormBase {
	public override WaveType Type => WaveType.Sawtooth;

	public override float GetOffset(float time, float wavelength, float amplitude, float phase) {
		return (2 * Mathf.PI / amplitude) * Mathf.Atan(Mathf.Tan((BaseScale * (2 * Mathf.PI * time - phase)) / (2 * wavelength)));
	}
}
