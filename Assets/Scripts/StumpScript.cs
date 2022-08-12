using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpScript : MonoBehaviour
{
    // color change when selected
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Save Target
    private List<GameObject> victims = new List<GameObject>();
    private bool isFull = false;

    public void SetLinkedStumps(List<StumpScript> stumps)
    {
        return;
    }

    public GameObject GetZoombini()
    {
        return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zoombini") && !isFull)
        {
            // Debug.Log("Stump OnTriggerEnter!!");
            victims.Add(other.gameObject);
            // gameObject.tag = "FullStump";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("Stump OnTriggerExit..");
        if (other.CompareTag("Zoombini") && !isFull)
        {
            victims.Remove(other.gameObject);
            // gameObject.tag = "stump";
            // gameObject.GetComponent<CircleCollider2D>().enabled = false;
            // gameObject.tag = "FullStump";
        }
    }

    public void OnTouchFinish(GameObject obj)
    {
        if (!victims.Contains(obj)) return;
        isFull = true;
        obj.transform.position = transform.position;
    }

    public void OnTouchStart(GameObject obj)
    {
        if (!victims.Contains(obj)) return;
        isFull = false;
    }
}
