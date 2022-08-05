using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZoombinis : MonoBehaviour
{
    [SerializeField] private GameObject zoombiniPrefab;
    [SerializeField] private int count = 16;

    void Start()
    {
        int len = (int)Mathf.Sqrt(count);
        int less = count;

        for (int x = 0; x < len; x++)
        {
            for (int y = 0; y < len; y++)
            {
                GameObject clone = Instantiate(zoombiniPrefab, new Vector3(x, y, 0), Quaternion.identity);
                Zoombini zoombini = clone.GetComponent<Zoombini>();

                zoombini.ChangeType(
                    Random.Range(0, 5),
                    Random.Range(0, 5),
                    Random.Range(0, 5),
                    Random.Range(0, 5)
                );
                count--;
            }
        }

        for (int x = 0; x < count; x++)
        {
            GameObject clone = Instantiate(zoombiniPrefab, new Vector3(x, len, 0), Quaternion.identity);
            Zoombini zoombini = clone.GetComponent<Zoombini>();

            zoombini.ChangeType(
                Random.Range(0, 5),
                Random.Range(0, 5),
                Random.Range(0, 5),
                Random.Range(0, 5)
            );
        }
    }
}
