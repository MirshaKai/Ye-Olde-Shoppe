using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Tasks : MonoBehaviour {
	public static Tasks instance;
	public Text debugPanel; 

	private List<GameObject> tasks = new List<GameObject>();

	void Awake() {
		instance = this;
	}

	void Update() {
		// If we don't have anything to do, get get resources!
		if (this.tasks.Count == 0) { 
			this.tasks.Add(TreeFactory.instance.CreateTree());
		}

		if (Debug.isDebugBuild) {
			this.debugPanel.text = "";
			int maxDebug = Math.Min(tasks.Count, 5);

			for (int i = 0; i < maxDebug; i++) {
				this.debugPanel.text += "Get: " + tasks[i].name + Environment.NewLine;
			}
		}
	}

	public void RemoveTask(GameObject task) {
		this.tasks.Remove (task);
	}

}
