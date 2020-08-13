using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleWave : WaveFormBase {
	public override WaveType Type => WaveType.Triangle;

	public override float GetOffset(float time, float wavelength, float amplitude, float phase) {
		return (2 * amplitude / Mathf.PI) * Mathf.Asin(Mathf.Sin((BaseScale * (2 * Mathf.PI * time - phase)) / wavelength));
	}
}
