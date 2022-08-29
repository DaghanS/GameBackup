using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Collector : MonoBehaviour
{
    public GameObject inventory; 
    public TextMeshProUGUI nameText;
    void Start()
    {
        nameText.text = gameObject.transform.root.name; // root = first parent
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }
    public void Collect()
    {
        nameText.gameObject.SetActive(true);
        this.GetComponent<Animator>().Play("Collected");
        Gear item = this.GetComponentInChildren<Gear>();
        inventory.GetComponent<Inventory>().CollectItem(item);
        // collect the object into backpack
        // Run collected animation that destroys the object
    }
}
