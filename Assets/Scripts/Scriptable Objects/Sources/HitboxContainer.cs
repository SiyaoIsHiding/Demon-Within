using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to contain a reference to all hitboxes so that all enemies can reference these
[CreateAssetMenu(fileName = "Hitbox Container", menuName = "ScriptableObjects/HitboxContainer")]
public class HitboxContainer : ScriptableObject
{
    public List<GameObject> hitboxes;
}
