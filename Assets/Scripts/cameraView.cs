using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraView : MonoBehaviour {

	public int cameraZoom;

	Camera cam;

	void Start () {
		cam = GetComponent<Camera> ();
		cameraZoom = 11;
	}

	void Update () {
		if (Input.GetKey (KeyCode.LeftControl) && Input.GetAxis("Mouse ScrollWheel") != 0) {
			if (Input.GetAxis("Mouse ScrollWheel") > 0) {
				cameraZoom--;
			} else {
				cameraZoom++;
			}
			if (cameraZoom >= 20) {//max zoom
				cameraZoom = 20;
			} else if (cameraZoom <= 2) {//min zoom
				cameraZoom = 2;
			}
			cam.orthographicSize = cameraZoom;
		}
	}
}
