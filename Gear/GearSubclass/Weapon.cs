using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string type;             // type and animator are linked, every type has their own animation.
    // also every type has its own scaling.
    public string adjective; // adjective bonuses.
    public string enchantment; // enchantment bonuses

    public float damage;            // attack damage.
    public float attackSpeed;       // changes animation speed.
    
    // will add three slots that can be filled with randomised effects = poison, bleeding, status effects, speed bonus, range bonus etc.


}