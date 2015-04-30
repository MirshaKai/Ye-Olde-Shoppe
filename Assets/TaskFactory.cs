using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaskFactory : MonoBehaviour {
	private List<GameObject> objects = new List<GameObject>();

	// Destroys a tree and updates the factory
	public void Remove(GameObject entity) {
		objects.Remove (entity);
		Destroy (entity);
	}
}
