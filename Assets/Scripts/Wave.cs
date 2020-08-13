using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Wave : MonoBehaviour {

	public WaveDescriptor description;
	private LineRenderer lineRenderer;

	// Start is called before the first frame update
	void Start() {
		if (description == null) return;

		description.GenerateBasePoints();
		lineRenderer = GetComponent<LineRenderer>();

		lineRenderer.positionCount = description.NumberOfPoints;
		lineRenderer.SetPositions(description.GetWavePoints());
	}

	// Update is called once per frame
	void Update() {

	}
}
