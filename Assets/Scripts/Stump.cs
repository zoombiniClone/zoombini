using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : MonoBehaviour
{
    [SerializeField] private Sprite[] stumpSprite;

    private SpriteRenderer stpRenderer;

    void Awake()
    {
        stpRenderer = transform.GetComponent<SpriteRenderer>();
    }

    public void ChangeType(int num)
    {
        stpRenderer.sprite = stumpSprite[num];
    }

}
