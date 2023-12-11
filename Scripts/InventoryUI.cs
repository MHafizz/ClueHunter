using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI itemNumber;
    // Start is called before the first frame update
    void Start()
    {
        itemNumber = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateItemNumber(PlayerInventory playerInventory){
        itemNumber.text = playerInventory.NumberOfItems.ToString();
    }
}
