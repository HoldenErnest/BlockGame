using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	public float speed;
	public float maxSpeed;
	int jumps;
	public int maxJumps;
	public float jumpHeight;
	bool canDash = false;
	bool right;
	public float dashSpeed;

	int velocityOnLand;
	bool fallDamaged = false;
	public int maxFall;
	public int maxHP;
	public static int health;
	public static float x, y, z;

	private Rigidbody2D rb2d;
	public GameObject inventoryGM;
	CapsuleCollider2D bottomColl;
	public GameObject jumpE;

	void Start() {
		bottomColl = GetComponent<CapsuleCollider2D> ();
		rb2d = GetComponent<Rigidbody2D> ();

		health = maxHP;
	}
	void Update() {
		save.loadState = false;
		save.saveState = false;
		if (Input.GetKeyDown (KeyCode.O))
			save.saveState = true;
		if (Input.GetKeyDown (KeyCode.L))
			save.loadState = true;

		//random information--------------

		//Debug.Log ("FPS: " + Mathf.Round(1/Time.deltaTime));//FPS
		x = transform.position.x; y = transform.position.y; z = transform.position.z;

		//[]random information-----------

		//open inventory
		if ((Input.GetKeyDown (KeyCode.E) && !GetInputs.editing) || Input.GetKeyDown(KeyCode.Escape)) {
			inventoryGM.gameObject.SetActive(!inventoryGM.gameObject.activeSelf);
		}


		//Deaths---------------------------------------------------------

		if (health <= 0) {
			rb2d.velocity = new Vector2 (0, 0);
			transform.position = new Vector2 (Mathf.Round(SpawnPoint.setSpawn.x), Mathf.Round(SpawnPoint.setSpawn.y + 1));
			health = maxHP;
			//died by hp loss
		}

		if (transform.position.y < -100) {
			rb2d.velocity = new Vector2 (0, 0);
			transform.position = new Vector2 (Mathf.Round(SpawnPoint.setSpawn.x), Mathf.Round(SpawnPoint.setSpawn.y + 1));
			health = maxHP;

			//died by void
		}

		//[]Deaths------------------------------------------------------[]

		//MOVEMENT------------------------------------------------------------------------------------------------------------------
		float xInput = Input.GetAxis ("Horizontal");
		Vector2 movementX = new Vector2 (xInput, 0);
		Vector2 movementY = new Vector2 (0, jumpHeight);
		if ((rb2d.velocity.x < maxSpeed && xInput > 0) || (rb2d.velocity.x > -maxSpeed && xInput < 0)) {//if  the current velocity is less then the max-speed if right Pressed, OR same for left
			rb2d.AddForce (movementX * speed);
		}
		if (Input.GetKeyDown (KeyCode.W) && jumps > 0) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);//reset y velocity for more power on great falls
			spawnJump();
			rb2d.AddForce (movementY * 20);
			jumps--;
		}
		//dash
		if (canDash && ((Input.GetKeyDown(KeyCode.A) && !right) || (Input.GetKeyDown(KeyCode.D) && right))) {
			spawnJump ();
			if (right)
				rb2d.velocity = new Vector2 (dashSpeed, rb2d.velocity.y);
			else rb2d.velocity = new Vector2 (-dashSpeed, rb2d.velocity.y);
			canDash = false;
		}
		if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && !canDash) {//horizontal key pressed and it was pressed within part of a few seconds ago
			canDash = true;
			StartCoroutine(dashWait());
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			right = true;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			right = false;
		}

		//[]MOVEMENT-------------------------------------------------------------------------------------------------------------[]

		if (rb2d.velocity.y <= -maxFall) {
			fallDamaged = true;
			velocityOnLand = Mathf.RoundToInt(rb2d.velocity.y);
		}

	}//end of update funtion

	void OnCollisionStay2D(Collision2D coll) {
		if (bottomColl.IsTouching(coll.collider) && coll.gameObject.tag.Contains("Block")) {//bottom of player touching a block
			jumps = maxJumps - 1;
			if (fallDamaged && !coll.gameObject.name.Contains("SpawnSetter")) {
				if (velocityOnLand >= -42) {
					health += (velocityOnLand / 7);
				} else if (velocityOnLand >= -52){
					health += (velocityOnLand / 4);
				} else {
					health += (velocityOnLand / 2);
				}
			}
			fallDamaged = false;
		}
	}

	void spawnJump() {
		fallDamaged = false;
		var jumpP = (GameObject)Instantiate (jumpE, transform.position, Quaternion.identity);
		Destroy(jumpP, 2f);
	}

	IEnumerator dashWait() {
		yield return new WaitForSeconds (0.2f);
		canDash = false;
	}

}
