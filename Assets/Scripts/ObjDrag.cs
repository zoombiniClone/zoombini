using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDrag : MonoBehaviour
{
    // color change
    // [SerializeField] private SpriteRenderer spriteRenderer;
    // Save Stump
    // [SerializeField] private GameObject obj;
    // private Vector3 loadedPos;

    private SpriteRenderer spriteRenderer;
    private List<GameObject> footholdObjects = new List<GameObject>();
    Vector2 startPos;
    Vector3 previousPos;
    bool isBeingHeld = false;
    // original Color
    Color originColor;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // loadedPos = transform.position;
        originColor = spriteRenderer.color;
    }

    private void Update() 
    {
        if(isBeingHeld)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = mousePos - startPos;
        }
    }


    #region Mouse Drag and Drop

    private void OnMouseDown()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
        Vector3 mousePos;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        startPos = mousePos - transform.position;
        previousPos = transform.position;

        isBeingHeld = true;

        // leave hold
        GameObject footholdObject = GetNeareastFootholdObject();

        if (footholdObject)
        {
            if (footholdObject.GetComponent<StumpScript>() != null)
            {
                footholdObject.GetComponent<StumpScript>().OnTouchStart(gameObject);
            }

            footholdObject = null;
        }
    }

    private void OnMouseUp() 
    {
        // spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        spriteRenderer.color = originColor;
        isBeingHeld = false;

        transform.position = previousPos;

        // hold check
        GameObject footholdObject = GetNeareastFootholdObject();

        if (footholdObject)
        {
            if (footholdObject.GetComponent<StumpScript>() != null)
            {
                footholdObject.GetComponent<StumpScript>().OnTouchFinish(gameObject);
            }
        }
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D other)
    {
        footholdObjects.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        footholdObjects.Remove(other.gameObject);
    }

    private GameObject GetNeareastFootholdObject()
    {
        GameObject neareastObject = null;

        footholdObjects.ForEach((obj) =>
        {
            if (neareastObject == null)
            {
                neareastObject = obj;
            }
            else if (Vector3.Distance(neareastObject.transform.position, transform.position) > 
                     Vector3.Distance(obj.transform.position, transform.position))
            {
                neareastObject = obj;
            }
        });

        return neareastObject;
    }
}