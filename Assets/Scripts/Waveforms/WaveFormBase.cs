using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaveFormBase {

	public abstract WaveType Type { get; }

	public const float BaseScale = 360;

	public abstract float GetOffset(float time, float wavelength, float amplitude, float phase);

}
