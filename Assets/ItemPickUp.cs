using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


public class ItemPickUp : MonoBehaviour
{
    private GameObject itemInRange;
    public GameObject ItemPickUpPanel;
    public float popupDuration = 10f;
    public TextMeshProUGUI pickupText;
    public event Action OnPickUp;

    /*private void Update()
    {
        if(itemInRange != null && Input.GetMouseButtonDown(1))
        {
            Debug.Log("Se levanto:" +  itemInRange.name);
            itemInRange.SetActive(false);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {

            Items item = other.GetComponent<Items>();
            if (item != null)
            {
                Debug.Log("panel activado????");
                StartCoroutine(ShowPickupPanel(item.pickupMessage));
            }

            Debug.Log("RECOGIDO" + other.name);
            other.gameObject.SetActive(false); // se borra
            
        }
    }

    private IEnumerator ShowPickupPanel(string message)
    {
        Debug.Log("Showing popup: " + message);
        pickupText.text = message;
        ItemPickUpPanel.SetActive(true);
        OnPickUp?.Invoke();
        yield return new WaitForSeconds(popupDuration);
        ItemPickUpPanel.SetActive(false);

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Pickup") && other.gameObject == itemInRange)
        {
            itemInRange = null;
        }

    }
}
