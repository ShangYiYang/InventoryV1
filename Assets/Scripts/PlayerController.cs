using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Inventory inv;
	public Item test;
	public int count;

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			if (inv.isEmpty ()) {
				inv.add (test);
			} else {
				Item temp = ScriptableObject.CreateInstance<Item> ();
				temp.itemName = count + " ";
				inv.add (temp);
			}
			count++;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			inv.printItems ();
		}
	}

	void toggleInventory() {
		GameObject invCanvas = GameObject.Find ("Canvas");
		if (invCanvas.GetComponent<Canvas> ().enabled) {
			invCanvas.GetComponent<Canvas> ().enabled = false;
		} else {
			invCanvas.GetComponent<Canvas> ().enabled = true;
			inv.displayItems ();
		}
	}
}
