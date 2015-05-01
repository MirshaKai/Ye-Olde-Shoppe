using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeFactory : TaskFactory {
	public static TreeFactory instance;
	public GameObject spawnArea;
	public GameObject targetObject;
	public int treeLimit = 10;

	void Awake() {
		instance = this;
	}

	// Creates a tree and finds a place to put it
	public GameObject CreateTree() {
		// Sanity check to prevent run away tree creation
		if (this.objects.Count < this.treeLimit) {
			GameObject newTarget = GameObject.Instantiate (targetObject);
			Vector3 newPosition = this.CreateVector();

			if (newPosition == Vector3.one) {
				return null;
			}

			newTarget.transform.position = this.CreateVector();

			Add (newTarget);
			return newTarget;
		} else {
			Debug.Log("Reached tree limit, not making any more");
		}

		return null;
	}

	// Gets a reference to a tree, creating one if needed
	public GameObject GetTree() {
		if (this.objects.Count == 0) {
			CreateTree ();
		}

		return this.objects [this.objects.Count - 1];
	}

	public Vector3 CreateVector() {
		Vector3 newPosition = this.MakeVector ();
		
		// Get some coordinates that aren't inside another object, exit if we struggle to find coordinates
		int loopCount = 0;
		while (Physics.CheckSphere(newPosition, 1.0f) && loopCount < 10) {
			loopCount++;
			newPosition = this.MakeVector ();
		}

		if (loopCount == 9) {
			Debug.Log ("Failed to find a location to place the object");
			return Vector3.one;
		}

		return newPosition;
	}

	// Creates a random set of coordinate on the spawn object
	private Vector3 MakeVector() {
		float randomX = Random.Range (-this.spawnArea.transform.lossyScale.x / 2, this.spawnArea.transform.lossyScale.x / 2);
		float randomY = Random.Range (-this.spawnArea.transform.lossyScale.y / 2, this.spawnArea.transform.lossyScale.y / 2);
		Vector3 newPosition = new Vector3(randomX, 1.5f, randomY);
		newPosition += spawnArea.transform.position;
		return newPosition;
	}
}
