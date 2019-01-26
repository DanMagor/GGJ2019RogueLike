using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour {

    public string itemName;

	// Use this for initialization
	void Start () {
        GameManager.itemsRemaining = GameManager.itemsRemaining + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        var collisionTag = collision.gameObject.tag;
        if (collisionTag == "Player")
        {
            Debug.Log("Collected the item: " + itemName);
            GameManager.itemsRemaining = GameManager.itemsRemaining - 1;
            GameManager.checkItems();
            gameObject.SetActive(false);
        }

    }
}
