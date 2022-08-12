using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoombini : MonoBehaviour
{
    [SerializeField] private int hair = 0;
    [SerializeField] private int eyes = 0;
    [SerializeField] private int nose = 0;
    [SerializeField] private int legs = 0;

    [SerializeField] private Sprite[] hairSprites;
    [SerializeField] private Sprite[] eyesSprites;
    [SerializeField] private Sprite[] noseSprites;
    [SerializeField] private Sprite[] legsSprites;

    private SpriteRenderer hairRenderer;
    private SpriteRenderer eyesRenderer;
    private SpriteRenderer noseRenderer;
    private SpriteRenderer legsRenderer;

    void Awake()
    {
        hairRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        eyesRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        noseRenderer = transform.GetChild(2).GetComponent<SpriteRenderer>();
        legsRenderer = transform.GetChild(3).GetComponent<SpriteRenderer>();
    }

    public void ChangeType()
    {
        hairRenderer.sprite = hairSprites[hair];
        eyesRenderer.sprite = eyesSprites[eyes];
        noseRenderer.sprite = noseSprites[nose];
        legsRenderer.sprite = legsSprites[legs];
    }

    public void ChangeType(int hairType, int eyesType, int noseType, int legsType)
    {
        hair = hairType;
        eyes = eyesType;
        nose = noseType;
        legs = legsType;

        ChangeType();
    }

    public int[] GetType() {
        return new int[4]{hair, eyes, nose, legs};
    }
}
