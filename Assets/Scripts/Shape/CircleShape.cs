using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Circle", menuName = "Wave Base Shapes/Circle", order = 1)]
public class CircleShape : ShapeBase {
	[SerializeField]
	private Vector2 centre;

	[SerializeField, Range(0, 2 * Mathf.PI)]
	private float startAngle = 0;

	[SerializeField, Range(0, 2 * Mathf.PI)]
	private float endAngle = 2 * Mathf.PI;

	[SerializeField, Range(.01f, 20)]
	private float radius = 5;

	public override Vector3 ApplyPointModification(Vector3 point, float height) {
		var normal = (point - Centre).normalized;

		return point + height * normal;
	}

	public override Vector3[] GeneratePoints() {
		var points = new Vector3[NumberOfPoints];
		var stepAngle = (EndAngle - StartAngle) / (NumberOfPoints - 1);

		for (int i = 0; i < NumberOfPoints; i++) {
			var currentAngle = StartAngle + i * stepAngle;

			var sinAngle = Mathf.Sin(currentAngle);
			var cosAngle = Mathf.Cos(currentAngle);

			points[i] = Centre + new Vector3(sinAngle, cosAngle) * Radius;
		}

		return points;
	}

	private Vector3 Centre => new Vector3(centre.x, centre.y);
	private float StartAngle => startAngle;
	private float EndAngle => endAngle;
	private float Radius => radius;
}
