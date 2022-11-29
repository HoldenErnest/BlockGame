using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour {

	//reload scene: SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	public bool timedSwap = true;
	bool clicked = false;
	public float waitTime;
	public string swapTo;
	public SpriteRenderer SR;
	public Sprite over;
	public Sprite notOver;

	void Start () {
		if (timedSwap) {
			StartCoroutine (Waits ());
		}
	}

	void Update () {
		if (!timedSwap && clicked) {
			SceneManager.LoadScene (swapTo);
		}

	}

	IEnumerator Waits() {
		yield return new WaitForSeconds(waitTime);
		SceneManager.LoadScene (swapTo);
	}

	void OnMouseDown () {
		clicked = true;
	}

	void OnMouseEnter () {
		SR.sprite = over;
	}
	void OnMouseExit () {
		SR.sprite = notOver;
	}

}
