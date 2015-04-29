using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIUpdate : MonoBehaviour {

	private Text main;

	// Use this for initialization
	void Start () {
		this.main = this.gameObject.GetComponent<Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		this.main.text = "Wood: " + WoodStock.instance.wood;
	}
}
