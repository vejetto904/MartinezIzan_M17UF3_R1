using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (fileName = "NewItem",menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    new public string name = "";
    public Sprite Sprite;
    public float damage = 0f;
    public float radius = 0f;
    public bool isExplosive = false;
    public GameObject prefab;
}
