using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDrag : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject obj;
    public Vector3 LoadedPos;
    float startPosx, startPosY, finPosX, finPosY;
    bool isBeingHeld = false;
    public bool isInLine;
    Color oriCol;

    private void Start() 
    {
        LoadedPos = this.transform.position;
        oriCol = this.spriteRenderer.color;
    }
    private void Update() 
    {
        if(isBeingHeld)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            this.gameObject.transform.position = new Vector2(mousePos.x - startPosx, mousePos.y - startPosY);
        }
    }


    #region 마우스 드래그앤 드롭

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            startPosx = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp() 
    {
        // spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        spriteRenderer.color = oriCol;
        isBeingHeld = false;

        if(isInLine)
        {
            this.gameObject.transform.position = new Vector3(finPosX, finPosY, -1f);
            obj.GetComponent<StumpScript>().isFull = true;

        }
        else
        {
            this.gameObject.transform.position = LoadedPos;
            obj.GetComponent<StumpScript>().isFull = false;
        }
    }

    #endregion
    
    #region 타임라인이랑 맞는지
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Obj OnTriggerEnter!!");
        obj = other.gameObject;
        if(other.CompareTag("stump") && obj.GetComponent<StumpScript>().isFull == false)
        {
            isInLine = true;
            finPosX = other.transform.position.x;
            finPosY = other.transform.position.y;
        }
        else
            ;
            // obj = null;
            // obj.Destroy();

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Obj OnTriggerExit...");
        if(other.CompareTag("FullStump") && other.gameObject.GetComponent<StumpScript>().isFull == true)
        {
            isInLine = false;
        }
    }


    #endregion
}