using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectItemDisplay : MonoBehaviour {

	Text displaying;
	public static string itemCollected;
	public static Vector2 goToPOS;
	private float ranOffset;

	void Start () {

		displaying = GetComponent<Text> ();

	}
		
	void Update () {

		//COMPLETELY REWORK WITH INSTANTIATIONS

		if (itemCollected != null) {
			ranOffset = Random.Range (0.1f, 0.5f);
			transform.position = new Vector3(goToPOS.x + ranOffset, goToPOS.y + ranOffset, this.transform.position.z);
			displaying.text = "+1 " + itemCollected;
			StartCoroutine (removed());
		}
		itemCollected = null;

	}
	IEnumerator removed() {
		yield return new WaitForSeconds (1.5f);
		displaying.text = "";
	}

}
