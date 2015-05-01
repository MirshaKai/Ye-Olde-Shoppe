using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskFactory : MonoBehaviour {
	protected List<GameObject> objects = new List<GameObject>();

	// Adds an object onto the factories internal list
	public void Add(GameObject entity) {
	}

	// Destroys a tree and updates the factory
	public void Remove(GameObject entity) {
		objects.Remove (entity);
		Destroy (entity);
	}
}
