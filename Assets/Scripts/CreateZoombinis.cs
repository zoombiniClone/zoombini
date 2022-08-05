using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZoombinis : MonoBehaviour
{
    [SerializeField] private GameObject zoombiniPrefab;
    [SerializeField] private int count = 16;
    [SerializeField] private float gap = 1;

    void Start()
    {
        int len = (int)Mathf.Round(Mathf.Sqrt(count));
        int less = count;
        Vector3 startPosition = new Vector3(-len * gap * 0.5f, -len * gap * 0.5f, 0);

        for (int x = 0; x < len; x++)
        {
            for (int y = 0; y < len; y++)
            {
                if (count <= 0) break;

                CreateZoombini(startPosition + new Vector3(x * gap, y * gap - x * 0.01f, 0));

                count--;
            }
        }

        for (int y = 0; y < count; y++)
        {
            CreateZoombini(startPosition + new Vector3(len * gap, y * gap - len * 0.01f, 0));
        }
    }

    void CreateZoombini(Vector3 pos)
    {
        GameObject clone = Instantiate(zoombiniPrefab, pos, Quaternion.identity);
        Zoombini zoombini = clone.GetComponent<Zoombini>();

        zoombini.ChangeType(
            Random.Range(0, 5),
            Random.Range(0, 5),
            Random.Range(0, 5),
            Random.Range(0, 5)
        );
    }
}
