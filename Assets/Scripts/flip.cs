using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour {

	void OnMouseOver() {
		if (Input.GetKeyDown(KeyCode.Tab) && Input.GetMouseButton(1)) {
			transform.eulerAngles += new Vector3 (0, 0, 90);
		}
	}

}
