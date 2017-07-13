using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inventory Class.

[CreateAssetMenu]
public class Inventory : ScriptableObject {
	public Item front;
	public Item back;
	public int size;

	void start () {
		front = null;
		back = null;
		size = 0;
	}

	// Adds Item to inventory. Inspector shows type mismatch but everything works.
	// Update: Potential issue, look into later. When passing in item, and adding to inventory, it may just be pointing to item passed in.
	// could be bad in situation where npc gives item to player and item is deleted. Npc's item may be deleted as well.
	public void add(Item i) {
		Debug.Log ("in add");
		if (front == null && back == null) {
			front = i;
			back = i;
		} else {
			front.prev = i;
			i.next = front;
			i.prev = null;
			front = i;
		}

		size++;

	}

	// deletes item from inventory
	public void delete(string itemToDelete) {
		Item curr = front;

		while (curr != null && !itemToDelete.Equals(curr.itemName)) {
			Debug.Log (curr.itemName);
			curr = curr.next;
		}

		if (front == null || curr == null) {
			Debug.Log ("item not found");
			return;
		} else if (front == back && front.itemName.Equals(itemToDelete)) {
			front = null;
			back = null;
		} else if (front.itemName.Equals(itemToDelete)) {
			front = front.next;
			front.prev = null;
		} else if (back.itemName.Equals(itemToDelete)) {
			Item temp = back.prev;
			temp.next = null;
		} else if (curr != null) {
			Item temp = curr.prev;
			temp.next = curr.next;
			curr.next.prev = temp;
		}
		size--;
	}
		
	public void printItems() {
		Item temp = front;
		string list = "";

		while (temp != null) {
			list += temp.itemName + " ";
			temp = temp.next;
		}

		Debug.Log (list);

	}

	// Returns true if the inventory is empty, false otherwise.
	public bool isEmpty() {
		if (front == null) {
			return true;
		}
		return false;
	}

	// Creates list of sprites from inventory and returns it.
	// Note: test for when sprites are empty. think about how to populate inventory with items with sprites.
	public List<Sprite> getSprites() {
		
		List<Sprite> sprites = new List<Sprite>();
		Item curr = front;

		while (curr != null) {
			if (curr.image != null) {
				sprites.Add(curr.image);
			}
			curr = curr.next;
		}

		return sprites;
	}
}
