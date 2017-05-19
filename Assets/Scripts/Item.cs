using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Item Class. 

[CreateAssetMenu]
public class Item : ScriptableObject {
	public Sprite image;
	public string itemName;
	public string desc;
	public Item next;
	public Item prev;
}
