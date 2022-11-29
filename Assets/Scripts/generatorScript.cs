using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorScript : MonoBehaviour {

	public GameObject product;
	private float ranNum;
	private bool canProduce = true;
	public BoxCollider2D detector;

	void Start() {
		StartCoroutine(wait());
	}

	void OnTriggerStay2D(Collider2D coll) {//somthing in the way
			canProduce = false;
	}
	void OnTriggerExit2D(Collider2D coll) { //somthings not in the way anymore
			canProduce = true;
			ranNum = Random.Range (0.75f, 1.25f);
			StartCoroutine(wait());
	}


	IEnumerator wait() {
		yield return new WaitForSeconds (ranNum);
		if (canProduce)
			Instantiate (product, new Vector2 (transform.position.x, transform.position.y + 1), Quaternion.identity);
	}
}
