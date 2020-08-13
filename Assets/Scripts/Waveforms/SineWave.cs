using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWave : WaveFormBase {
	public override WaveType Type => WaveType.Sine;

	public override float GetOffset(float time, float wavelength, float amplitude, float phase) {
		return amplitude * Mathf.Sin((BaseScale * (2 * Mathf.PI * time - phase)) / wavelength);
	}
}
