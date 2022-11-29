using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public Text searchText;
	public static GameObject[] Items;
	public static int[] ItemAmmounts;
	public GameObject defaultItem;
	public static string searchInfo;
	//the inspector-editable items
	public GameObject[] ItemsOnEntry;

	bool allItems = false;
	public static bool mouseInInventory = false;

	int aVar = 0;//temperary help for hotbar and items


	//START METHOD
	void Start () {
		Items = ItemsOnEntry;
		ItemAmmounts = new int[Items.Length];

	}
	
	// Update is called once per frame
	void Update () {
		searchInfo = searchText.text;

		for (int i = 0; i < Items.Length; i++) { //runs through each item
			if (!allItems) {
				CreateItem (i, Items[i]);
			}
		}
		allItems = true;

	}
	void CreateItem(int id, GameObject named) {//make a new item with its gameObject and ID.
		var anItem = (GameObject)Instantiate (defaultItem, new Vector3(this.transform.position.x - 7, this.transform.position.y - aVar + 3, this.transform.position.z), Quaternion.identity);

		// Add velocity to the bullet
		anItem.GetComponent<ItemInfo>().Item = named;
		anItem.GetComponent<ItemInfo> ().numID = id;
		anItem.transform.SetParent (this.transform);
		anItem.transform.localScale = new Vector3(1, 1, 1);
		aVar++;//aVar is just used as a temporary way to see and click the text easily
	}
}
