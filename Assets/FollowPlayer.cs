using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	private GameObject focus;
	private GameObject something;

	void Awake() {
		focus = GameObject.Find ("Mover");
	}

	// Update is called once per frame
	void Update () {
		Vector3 newPosition = new Vector3 (focus.transform.position.x, 30.0f, focus.transform.position.z);
		this.transform.position = newPosition;
	}
}
