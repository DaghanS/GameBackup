using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearInfo
{
    // STATS //
    public Object gearObj { get; set; } // Weapon / Armor / Cursed // CHEST !!! //
    // on object ==> type info = every type has its own stat scaling // will be determined by prefabs
    // on object ==> adjective 
    // on object ==> enchantment
    public string rarity { get; set; }       // could turn into class object
    public int level { get; set; }
    // STATS //

    public Icon iconvar { get; set; }
}
