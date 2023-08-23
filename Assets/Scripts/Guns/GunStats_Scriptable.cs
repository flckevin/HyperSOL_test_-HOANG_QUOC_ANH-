using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GunStats", menuName = "ScriptableObjects/GunStats")]
public class GunStats_Scriptable : ScriptableObject
{
    public float fireRate;
    public float damage;
    public AudioClip gunClip;
}
