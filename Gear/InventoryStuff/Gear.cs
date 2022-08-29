using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for image in Icon.

public class Gear : MonoBehaviour
{
    // STATS //
    public Object gearObj; // Weapon / Armor / Cursed // CHEST !!! //
    // on object ==> type info = every type has its own stat scaling // will be determined by prefabs
    // on object ==> adjective 
    // on object ==> enchantment
    public string rarity;       // could turn into class object
    public int level;
    // STATS //

    public Icon iconvar;
}
