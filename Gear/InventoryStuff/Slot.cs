using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int[] coordinates;
    public GearInfo storedGear;

    //void SlotUIControl(Gear storedGear)
    //{
    //    // was on awake
    //    if (storedGear != null)
    //    {
    //        //Icon
    //        Transform icon = gameObject.transform.Find("Icon_gear");
    //        icon.GetComponent<SpriteRenderer>().sprite = storedGear.iconvar.iconObject;
    //        // color
    //        Transform color = gameObject.transform.Find("color_type");
    //        color.GetComponent<SpriteRenderer>().sprite = storedGear.iconvar.typeColor;
    //        // border
    //        Transform border = gameObject.transform.Find("border_rarity");
    //        border.GetComponent<SpriteRenderer>().sprite = storedGear.iconvar.rarityBorder;
    //        // animator controller  // WORKS WITH ANIMATOR, COULD BE WRONG SHOULD BE CHECKED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //        Animator effect = this.GetComponent<Animator>();
    //        Animator storedAnim = storedGear.iconvar.adjEffect;
    //        effect.runtimeAnimatorController = storedAnim.runtimeAnimatorController;
    //    }
    //    // Load gear info?
    //}
    public void Awake()
    {
        if (storedGear != null)
        {
            //Icon
            Transform icon = gameObject.transform.Find("Icon_gear");
            icon.GetComponent<SpriteRenderer>().sprite = storedGear.iconvar.iconObject;
            // color
            Transform color = gameObject.transform.Find("color_type");
            color.GetComponent<SpriteRenderer>().sprite = storedGear.iconvar.typeColor;
            // border
            Transform border = gameObject.transform.Find("border_rarity");
            border.GetComponent<SpriteRenderer>().sprite = storedGear.iconvar.rarityBorder;
            // animator controller  // WORKS WITH ANIMATOR, COULD BE WRONG SHOULD BE CHECKED !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Animator effect = this.GetComponent<Animator>();
            Animator storedAnim = storedGear.iconvar.adjEffect;
            effect.runtimeAnimatorController = storedAnim.runtimeAnimatorController;
        }
    }
}
