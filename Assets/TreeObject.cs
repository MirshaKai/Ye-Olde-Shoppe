using UnityEngine;
using System.Collections;

public class TreeObject : MonoBehaviour {
	public GameObject user;

	public void OnDestroy() {
		// Remove object from task list
		Tasks.instance.RemoveTask (this.gameObject);

		// Remove tree from the tree factory
		TreeFactory.instance.Remove (this.gameObject);

	}
}
