using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	public Inventory inv;
	public Item test1;
	public Item test2;
	public Item test3;
	public List<Transform> tabs;
	public int tabIndex;
	public int count;

	// Use this for initialization
	void Start() {
		count = 0;
		tabIndex = 0;
		inv = ScriptableObject.CreateInstance<Inventory>();
		fillTabsBar ();
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.A)) {
			Item temp = ScriptableObject.CreateInstance<Item>();
			temp.itemName = count + "";
			inv.add(test1);
			inv.add(test2);
			inv.add(test3);
			count++;
		}

		if (Input.GetKeyDown(KeyCode.P)) {
			inv.printItems();
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			string itemName = count - 1 + "";
			inv.delete(test1.itemName);
			count--;
		}

		if (Input.GetKeyDown(KeyCode.I)) {
			toggleInventory();
		}

		if (Input.GetKeyDown(KeyCode.Q)) {
			switchTabsLeft();
		}

		if (Input.GetKeyDown(KeyCode.E)) {
			switchTabsRight();
		}
	}

	void toggleInventory() {
		GameObject invCanvas = GameObject.Find("Canvas");

		if (invCanvas.GetComponent<Canvas>().enabled) {
			invCanvas.GetComponent<Canvas>().enabled = false;
		} else {
			invCanvas.GetComponent<Canvas>().enabled = true;
			displayItems();
		}
	}

	public void displayItems() {
		// get array of image elements
		// for length of array, fill from front

		RectTransform grid = GameObject.Find("Grid").GetComponent<RectTransform>();
		List<Sprite> sprites = inv.getSprites();
		int count = 0;

		foreach (Transform slot in grid) {
			foreach (Transform image in slot) {
				Debug.Log (image.name + " " + sprites.Count);
				if (count < sprites.Count) {
					image.GetComponent<Image>().sprite = sprites[count];
					count++;
				}
			}
		}
	}

	public void switchTabsLeft() {
		Transform temp = tabs[tabs.Count - 1];

		tabs.RemoveAt(0);
		tabs.Add(temp);
			
	}

	public void switchTabsRight() {

	}

	public void fillTabsBar() {
		Transform tabsBar = GameObject.Find("Tabs Bar").GetComponent<Transform> ();

		foreach (Transform tab in tabsBar) {
			tabs.Add(tab);
			Debug.Log(tab.name);
		}
	}
}