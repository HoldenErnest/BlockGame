using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	public static Vector2 setSpawn;

	void Start () {
		setSpawn = transform.position;
	}
	void OnDestroy() {
		setSpawn = new Vector2 (0, 0);
	}
}
