using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveDescription", menuName = "Wave Description")]
public class WaveDescriptor : ScriptableObject {

	public ShapeBase WaveShape { get; set; }
	public WaveFormBase WaveForm { get; set; } = new SineWave();

	public Vector3[] BasePoints { get; private set; }

	public void GenerateBasePoints() {
		BasePoints = WaveShape.GeneratePoints();
	}
}
