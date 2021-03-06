﻿using UnityEngine;
using System.Collections;

public class PursueTarget : MonoBehaviour {
	private NavMeshAgent navAgent;
	private GameObject target;
	private GameObject holding;
	private GameObject test;

	// Use this for initialization
	void Start () {
		navAgent = this.transform.GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		if (target) {
			navAgent.SetDestination (target.transform.position);
		} else {
			target = Tasks.instance.GetTask();
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Target" && other.gameObject.name == target.name) {
			target = WoodStock.instance.GetDestinationBin ();
			other.gameObject.SetActive(false);
			this.holding = other.gameObject;
		} else if (other.gameObject.tag == "WoodBin" && this.holding != null) {
			target = Tasks.instance.GetTask();
			target.gameObject.GetComponent<TreeObject>().user = this.gameObject;
			this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			WoodStock.instance.AddWood(1);
			Destroy(this.holding);
			this.holding = null;
		} else {
			Debug.Log ("Unknown collision: " + other.gameObject.name);
		}
	}
}
