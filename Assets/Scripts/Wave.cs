using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Wave : MonoBehaviour {

	[HideInInspector]
	public ShapeBase Shape;
	public bool additiveCombinations = true;
	public float totalAmplitude;
	public WaveDescriptor[] descriptions;

	private LineRenderer lineRenderer;
	private Vector3[] basePoints;

	// Start is called before the first frame update
	void Start() {
		if (descriptions == null || descriptions.Length == 0) return;

		GenerateBasePoints();
		lineRenderer = GetComponent<LineRenderer>();
	}

	public void GenerateBasePoints() {
		basePoints = Shape.GeneratePoints();
	}

	private Vector3[] TransformPoints(bool isAdditive = true) {
		var newPoints = new Vector3[Shape.NumberOfPoints];

		for (int i = 0; i < Shape.NumberOfPoints; i++) {
			float height = CombineHeights((float)i / (Shape.NumberOfPoints - 1), isAdditive);
			newPoints[i] = Shape.ApplyPointModification(basePoints[i], height);
		}

		return newPoints;
	}

	private float CombineHeights(float positionPercent, bool isAddititve) {
		float output;

		if (isAddititve) {
			output = 0;
			foreach (var description in descriptions) {
				output += description.GetUnitOffset(positionPercent);
			}

			output /= descriptions.Length;
		} else {
			output = 1;
			foreach (var description in descriptions) {
				output *= description.GetUnitOffset(positionPercent);
			}
		}

		return output * totalAmplitude;
	}

	// Update is called once per frame
	void Update() {
		if (descriptions == null || descriptions.Length == 0) return;

		lineRenderer.positionCount = Shape.NumberOfPoints;
		lineRenderer.SetPositions(TransformPoints(additiveCombinations));
	}
}
