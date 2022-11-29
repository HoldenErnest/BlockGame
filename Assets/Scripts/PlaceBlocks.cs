using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlocks : MonoBehaviour {

	private GameObject itemSelected;

	public static GameObject[] hotbar;
	public GameObject blockPlaceholder;
	private Vector2 mousePos;
	public LayerMask cantPlaceOn;

	//some special  items
	public GameObject emmitSpawner;
	public GameObject sBallItem;

	private bool breaksBlocks = false;
	public static bool canSwitchItems = true;
	private bool specialItem;
	int currentID;
	public float fireSpeed;
	bool canShoot = true;

	//slow break
	bool StartBreak = false;
	bool actualyBreak = false;
	public float breakSpeed;
	Vector3 oldMousePos;

	void Start() {
		hotbar = new GameObject[9];
		for (int i = 0; i < hotbar.Length; i++) hotbar[i] = null;
	}

	void Update () {
		


		//HOTBAR--------------------------------
		if (Input.GetKey (KeyCode.Alpha1) && canSwitchItems) {
			itemSelected = hotbar [0];
		}
		if (Input.GetKey (KeyCode.Alpha2) && canSwitchItems) {
			itemSelected = hotbar [1];
		}
		if (Input.GetKey (KeyCode.Alpha3) && canSwitchItems) {
			itemSelected = hotbar [2];
		}
		if (Input.GetKey (KeyCode.Alpha4) && canSwitchItems) {
			itemSelected = hotbar [3];
		}
		if (Input.GetKey (KeyCode.Alpha5) && canSwitchItems) {
			itemSelected = hotbar [4];
		}
		if (Input.GetKey (KeyCode.Alpha6) && canSwitchItems) {
			itemSelected = hotbar [5];
		}
		if (Input.GetKey (KeyCode.Alpha7) && canSwitchItems) {
			itemSelected = hotbar [6];
		}
		if (Input.GetKey (KeyCode.Alpha8) && canSwitchItems) {
			itemSelected = hotbar [7];
		}
		if (Input.GetKey (KeyCode.Alpha9) && canSwitchItems) {
			itemSelected = hotbar [8];
		}
		//[]HOTBAR------------------------------[]

		//FIND MOUSE IN BLOCK POSITION-------------------------------------------------------------------
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		blockPlaceholder.transform.position = new Vector3 (Mathf.Round (mousePos.x), Mathf.Round (mousePos.y), -4);

		if (Input.GetMouseButton (0)) {
			blockPlaceholder.gameObject.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0.5f);
		} else {
			blockPlaceholder.gameObject.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 1);
		}

		if (Input.GetMouseButton(0) && itemSelected != null) { //player clicked and an item is selected

			//detect special items
			if (itemSelected.name.Contains ("Pickaxe")) {
				breaksBlocks = true;
			} else {
				breaksBlocks = false;
			}
			if (itemSelected.name.Contains ("Pickaxe") || itemSelected.name.Contains ("Snowball")) {
				specialItem = true;
			} else {
				specialItem = false;
			}

			//blockPlaceHolder
			blockPlaceholder.transform.position = new Vector3 (blockPlaceholder.transform.position.x, blockPlaceholder.transform.position.y, -4);
			//Vector2 mouseRay = Camera.main.ScreenToWorldPoint (blockPlaceholder.transform.position);
			RaycastHit2D RayHit = Physics2D.Raycast (blockPlaceholder.transform.position, Vector2.zero, Mathf.Infinity, cantPlaceOn);
			//[]FIND MOUSE IN BLOCK POSITION----------------------------------------------------------------[]

			//PLACE A BLOCK---------------------------------
			if ((RayHit.collider == null || (RayHit.collider.gameObject.tag.Equals("BackgroundBlock") && !itemSelected.gameObject.tag.Equals("BackgroundBlock"))) && !breaksBlocks && !specialItem) {
				if (blockPlaceholder.transform.position.y >= -100 && blockPlaceholder.transform.position.y <= 150) {//only place blocks above here
					//REMOVE FROM INVENTORY------------------
					for (int i = 0; i < Inventory.Items.Length; i++) {//run through all Items
						if (itemSelected.name.Contains (Inventory.Items [i].name)) {
							if (Inventory.ItemAmmounts [i] > 0) {
								Inventory.ItemAmmounts [i]--;
								Instantiate (itemSelected, new Vector3(blockPlaceholder.transform.position.x, blockPlaceholder.transform.position.y, itemSelected.gameObject.transform.position.z), Quaternion.identity);//CREATE BLOCK------
							}
						}

					}
					//[]REMOVE FROM INVENTORY--------------[]
				}
				//[]PLACE A BLOCK----------------------------[]

				//BREAK A BLOCK--------------------------------------------------------------------
			} else if (RayHit.collider != null && breaksBlocks) {
				
				if (!StartBreak) {
					StartBreak = true;
					oldMousePos = blockPlaceholder.transform.position;
					StartCoroutine (BreakTimer());
				}
				if (actualyBreak) {
					if (oldMousePos == blockPlaceholder.transform.position) {
						//COLLECT THE BLOCK--------------
						for (int i = 0; i < Inventory.Items.Length; i++) {//run through all Items
							if (RayHit.collider.gameObject.name.Contains (Inventory.Items [i].name)) {
								Inventory.ItemAmmounts [i]++;
								CollectItemDisplay.goToPOS = blockPlaceholder.transform.position;
								CollectItemDisplay.itemCollected = Inventory.Items[i].name;
							}
						}
						//[]COLLECT THE BLOCK----------[]
						Destroy (RayHit.collider.gameObject);//DELETE BLOCK
					}
					StartBreak = false;
					actualyBreak = false;
				}

			}
			//[]BREAK A BLOCK---------------------------------------------------------------[]

		}//playerClicks and item selected -IF-
		//SPECIAL ITEM USE-----------------------------------------------
		if (itemSelected != null) {
			if (!Inventory.Items [currentID].name.Contains (itemSelected.name)) {//find special item id for item ammount comparison
				for (int i = 0; i < Inventory.Items.Length; i++) {
					if (Inventory.Items [i].name.Contains (itemSelected.name)) {
						currentID = i;
					}
				}
			}

			if (Input.GetMouseButton (0)) {
				if (Inventory.ItemAmmounts [currentID] > 0 && canShoot) {//test if the player has the item and clicked AKA use item
					if (itemSelected.name.Contains ("Snowball")) {
						shootSnowball ();
						Inventory.ItemAmmounts [currentID] -= 1;
						canShoot = false;
						StartCoroutine(fireRate());
					}
				}
			}
		}

	}//UPDATE FUNCTION

	void shootSnowball() {
		var snowball = (GameObject)Instantiate (sBallItem, emmitSpawner.transform.position, emmitSpawner.transform.rotation);

		float dirX = mousePos.x - emmitSpawner.transform.position.x;
		float dirY = mousePos.y - emmitSpawner.transform.position.y;
		if (dirY > 0)
			dirY = dirY * 2;
		else
			dirY = dirY / 2;

		if (Mathf.Abs(dirX) > 11)
			dirX = 11 * (dirX/Mathf.Abs(dirX));
		if (Mathf.Abs(dirY) > 9)
			dirY = 9 * (dirY/Mathf.Abs(dirY));

		snowball.GetComponent<Rigidbody2D> ().AddForce (new Vector2(dirX, dirY) * 100);
		Destroy(snowball, 5f);
	}

	IEnumerator BreakTimer() {
		yield return new WaitForSeconds (breakSpeed);
		actualyBreak = true;

	}
	IEnumerator fireRate() {
		yield return new WaitForSeconds (fireSpeed);
		canShoot = true;
	}

}