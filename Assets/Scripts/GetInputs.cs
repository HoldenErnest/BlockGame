using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GetInputs : MonoBehaviour {

	private InputField TextInput;
	public static bool editing = false;

	void Start () {
		TextInput = this.GetComponent<InputField> ();
	}

	void Update () {
		if (TextInput.isFocused) {
			editing = true;
		} else {
			editing = false;
		}
	}
}
