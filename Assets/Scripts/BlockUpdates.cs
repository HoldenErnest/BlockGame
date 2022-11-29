using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockUpdates : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.y < -100 || transform.position.y > 150) {
			Destroy (this.gameObject);
		}

	}
}
