using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Weapon : ScriptableObject
{
    public string name;
    public GameObject prefab;
    public float damage;
    public bool eqquiped = false;
}
