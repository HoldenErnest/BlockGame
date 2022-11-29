using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInfoDisplay : MonoBehaviour {

	private Text displaying;

	void Start () {
		displaying = GetComponent<Text> ();
	}

	void Update () {
		displaying.text = "[" + Mathf.Round (Controller.x) + ", " + Mathf.Round (Controller.y) + ", " + Mathf.Round (Controller.z) + "]\n" + "HP: " + Controller.health;

	}
}
