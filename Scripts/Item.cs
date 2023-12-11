using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        Debug.Log("Item OnTriggerEnter");
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if(playerInventory != null){
            playerInventory.ItemsCollected();
            Debug.Log("Item Collected");
            gameObject.SetActive(false);
        } else {
        Debug.LogError("PlayerInventory component not found on the player!");
    }
    }
}
