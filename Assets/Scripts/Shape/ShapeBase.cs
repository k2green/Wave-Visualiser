using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShapeBase : ScriptableObject {

	[SerializeField]
	private int numberOfPoints = 200;

	public abstract Vector3[] GeneratePoints();
	public abstract Vector3 ApplyPointModification(Vector3 point, float height);

	public int NumberOfPoints => numberOfPoints;
}
