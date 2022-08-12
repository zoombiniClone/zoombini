using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpScript : MonoBehaviour
{
    // color change when selected
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Save Target
    private List<GameObject> victims = new List<GameObject>();
    private List<StumpScript> linkedStumps = new List<StumpScript>();

    private GameObject victim = null;
    private bool isFull = false;

    public void SetLinkedStumps(List<StumpScript> stumps)
    {
        linkedStumps = stumps;
    }

    public void AddLinkedStump(StumpScript stump)
    {
        linkedStumps.Add(stump);
    }
    
    public GameObject GetZoombini()
    {
        return victim;
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

        int[] objTypes = obj.GetComponent<Zoombini>().GetType();
        foreach (StumpScript stump in linkedStumps)
        {
            if (stump.GetZoombini() == null) continue;

            int[] stumpTypes = stump.GetZoombini().GetComponent<Zoombini>().GetType();

            if (stumpTypes[0] != objTypes[0] 
             && stumpTypes[1] != objTypes[1]
             && stumpTypes[2] != objTypes[2]
             && stumpTypes[3] != objTypes[3]) 
            {
                return;
            }
        }

        isFull = true;
        victim = obj;
        obj.transform.position = transform.position;
    }

    public void OnTouchStart(GameObject obj)
    {
        if (!victims.Contains(obj)) return;
        isFull = false;
        victim = null;
    }
}
