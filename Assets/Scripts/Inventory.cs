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
	public void add(Item i) {
		Debug.Log ("in add");
		if (front == null && back == null) {
			Debug.Log ("empty");
			front = i;
			back = i;
		} else {
			Debug.Log ("not empty");
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

		if (!itemToDelete.Equals (curr.itemName)) {
			Debug.Log ("This works");
		}
		while (!itemToDelete.Equals(curr.itemName)) {
			Debug.Log (curr.itemName);
			curr = curr.next;
		}

		if (front == null) {
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
	}
		
	public void printItems() {
		Item temp = front;

		while (temp != null) {
			Debug.Log (temp.itemName);
			temp = temp.next;
		}

	}

	// Returns true if the inventory is empty, false otherwise.
	public bool isEmpty() {
		if (front == null) {
			return true;
		}
		return false;
	}

	public void displayItems() {
		// get array of image elements
		// for length of array, fill from front
	}
}
