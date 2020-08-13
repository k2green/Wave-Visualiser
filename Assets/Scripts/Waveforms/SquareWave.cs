using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareWave : WaveFormBase {
	public override WaveType Type => WaveType.Square;

	public override float GetOffset(float time, float wavelength, float amplitude, float phase) {
		if(BaseScale * (time - phase) % wavelength < wavelength / 2) {
			return amplitude;
		} else {
			return -amplitude;
		}
	}
}
