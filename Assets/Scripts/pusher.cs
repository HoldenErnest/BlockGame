using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pusher : MonoBehaviour {

	Vector2 mousePos;
	public Animator anim;

	void Start () {
		
	}

	void Update () {
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if (Mathf.Round(transform.position.x) == Mathf.Round (mousePos.x) && Mathf.Round(transform.position.y) == Mathf.Round (mousePos.y)) { //mouse touching block
			if (Input.GetMouseButtonDown(1)) { //player rightclicks-
				anim.SetBool("Pushing", !anim.GetBool("Pushing"));
			}
		}

	}
}
