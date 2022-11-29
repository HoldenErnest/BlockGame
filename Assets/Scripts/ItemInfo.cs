using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour {

	public GameObject Item;
	public int ItemAmmount;
	public int numID;

	public Text TXT;

	bool containsHotkey = false;

	void Start () {
		

	}
	//ITEM ID
	//ITEM NAME/GAMEOBJECT
	//ITEM AMMOUNT


	void Update () {




		ItemAmmount = Inventory.ItemAmmounts [numID];
		TXT.text = "";

		//UPDATE TEXTS--------------------------------------------------------------------------------
		if (Item.name.ToLower().Contains(Inventory.searchInfo.ToLower()) || Inventory.searchInfo == null) {
			TXT.text = TXT.text + numID + ":" + Item.name + "   ";

			for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
				if (PlaceBlocks.hotbar [j] == Item && PlaceBlocks.hotbar [j] != null) {//if any hotbar items are == to the current item
					TXT.text = TXT.text + (j + 1).ToString () + "   ";
					containsHotkey = true;
				}

			}
			if (!containsHotkey) {
				TXT.text = TXT.text + "-   ";
			}
			containsHotkey = false;
			TXT.text = TXT.text + ItemAmmount;
		}
		//[]UPDATE TEXTS-------------------------------------------------------------------------------[]

	}

	//HOTBAR-----------------------------------------------------------
	void OnMouseOver() {
		//REMINDER remember if any other hotbar slots have the item then set that slot to the current other slot or null
		if (Input.GetMouseButton(1)) {
			PlaceBlocks.canSwitchItems = false;

			if (Input.GetKey (KeyCode.Alpha1)) {
				for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
					if (PlaceBlocks.hotbar [j] == Item && j != 0) {
						PlaceBlocks.hotbar [j] = PlaceBlocks.hotbar[0];
					}
				}
				PlaceBlocks.hotbar [0] = Item;
			}
			if (Input.GetKey (KeyCode.Alpha2)) {
				for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
					if (PlaceBlocks.hotbar [j] == Item && j != 1) {
						PlaceBlocks.hotbar [j] = PlaceBlocks.hotbar[1];
					}
				}
				PlaceBlocks.hotbar [1] = Item;
			}
			if (Input.GetKey (KeyCode.Alpha3)) {
				for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
					if (PlaceBlocks.hotbar [j] == Item && j != 2) {
						PlaceBlocks.hotbar [j] = PlaceBlocks.hotbar[2];
					}
				}
				PlaceBlocks.hotbar [2] = Item;
			}
			if (Input.GetKey (KeyCode.Alpha4)) {
				for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
					if (PlaceBlocks.hotbar [j] == Item && j != 3) {
						PlaceBlocks.hotbar [j] = PlaceBlocks.hotbar[3];
					}
				}
				PlaceBlocks.hotbar [3] = Item;
			}
			if (Input.GetKey (KeyCode.Alpha5)) {
				for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
					if (PlaceBlocks.hotbar [j] == Item && j != 4) {
						PlaceBlocks.hotbar [j] = PlaceBlocks.hotbar[4];
					}
				}
				PlaceBlocks.hotbar [4] = Item;
			}
			if (Input.GetKey (KeyCode.Alpha6)) {
				for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
					if (PlaceBlocks.hotbar [j] == Item && j != 5) {
						PlaceBlocks.hotbar [j] = PlaceBlocks.hotbar[5];
					}
				}
				PlaceBlocks.hotbar [5] = Item;
			}
			if (Input.GetKey (KeyCode.Alpha7)) {
				for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
					if (PlaceBlocks.hotbar [j] == Item && j != 6) {
						PlaceBlocks.hotbar [j] = PlaceBlocks.hotbar[6];
					}
				}
				PlaceBlocks.hotbar [6] = Item;
			}
			if (Input.GetKey (KeyCode.Alpha8)) {
				for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
					if (PlaceBlocks.hotbar [j] == Item && j != 7) {
						PlaceBlocks.hotbar [j] = PlaceBlocks.hotbar[7];
					}
				}
				PlaceBlocks.hotbar [7] = Item;
			}
			if (Input.GetKey (KeyCode.Alpha9)) {
				for (int j = 0; j < PlaceBlocks.hotbar.Length; j++) {//go through all hotbars
					if (PlaceBlocks.hotbar [j] == Item && j != 8) {
						PlaceBlocks.hotbar [j] = PlaceBlocks.hotbar[8];
					}
				}
				PlaceBlocks.hotbar [8] = Item;
			}
		}
		PlaceBlocks.canSwitchItems = true;
	}
	void OnMouseUp() {
		PlaceBlocks.canSwitchItems = true;
	}

	//[]HOTBAR-------------------------------------------------------[]

}
