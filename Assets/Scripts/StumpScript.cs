using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject obj;
    public bool isFull = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && isFull == false)
        {
            Debug.Log("Stump OnTriggerEnter!!");
            // isFull = true;
            obj = other.gameObject;
            gameObject.tag = "FullStump";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Stump OnTriggerExit..");
        if(!isFull)
        {
            gameObject.tag = "stump";
        //    gameObject.GetComponent<CircleCollider2D>().enabled = false;
            // gameObject.tag = "FullStump";

        }

    }
}
