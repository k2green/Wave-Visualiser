using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareWave : SineWave {
	public override WaveType Type => WaveType.Square;

	public override float GetOffset(float time, float wavelength, float amplitude, float phase) {
		return Mathf.Sign(base.GetOffset(time, wavelength, 1, phase)) * amplitude;
	}
}
