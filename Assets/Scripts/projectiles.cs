using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectiles : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D Coll) {
		if (Coll.gameObject.tag.Equals ("Block")) { //make puff effect on destroy
			Destroy (this.gameObject, 0.05f);
		}
	}
}
