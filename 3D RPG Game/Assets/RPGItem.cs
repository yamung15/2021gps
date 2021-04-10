using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class RPGItem : ScriptableObject
{
	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;
	public virtual void Use()
	{
		Debug.Log(name);
	}
}
