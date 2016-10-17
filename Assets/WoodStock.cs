using UnityEngine;
using System.Collections;

public class WoodStock : MonoBehaviour {
	public static WoodStock instance;
	public GameObject binObject;
	public int wood = 5;

	// Use this for initialization
	void Awake () {
		instance = this;
	}

	public GameObject GetDestinationBin() {
		return binObject;
	}

	public void AddWood(int count) {
		this.wood += count;
	}
}
