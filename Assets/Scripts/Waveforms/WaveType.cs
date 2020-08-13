using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaveType {
	Sine, Square, Triangle, Sawtooth
}

public static class WaveTypeExtensions {
	public static WaveFormBase ToWaveForm(this WaveType waveType) {
		switch (waveType) {
			case WaveType.Sine:
				return new SineWave();
			case WaveType.Square:
				return new SquareWave();
			case WaveType.Triangle:
				return new TriangleWave();
			case WaveType.Sawtooth:
				return new SawtoothWave();
			default: throw new System.Exception($"Unsupported waveform {waveType}");
		}
	}
}
