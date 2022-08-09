using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongBoatScript : MonoBehaviour
{
    // making map
    [SerializeField] private GameObject stumpPrefab;
    [SerializeField] private int count = 16;
    
    void Start()
    {

        int len = count;
        Vector3 startPosition = new Vector3(-len * 0.5f, 0 * 0.5f, 0);

        for (int x = 0; x < len; x++)
        {
            CreateTongBoat(startPosition + new Vector3(x * 1.3f, 0, 0));
        }
    
    
    }

    void CreateTongBoat(Vector3 pos)
    {
        GameObject clone = Instantiate(stumpPrefab, pos, Quaternion.identity); // Quaternion.identity
        clone.transform.Rotate(60f, 0f, 0f);
        Stump stump = clone.GetComponent<Stump>();

        int num = Random.Range(0,4);
        stump.ChangeType(num);

    }


}