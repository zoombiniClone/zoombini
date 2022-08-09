using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapArray
{
    public GameObject[] map;
}

public class TongBoatScript : MonoBehaviour
{
    // Making stump map
    [SerializeField] private GameObject stumpPrefab;
    [SerializeField] private int count = 16;
    [SerializeField] private int stageNum = 2;  // stage : 1~4 (ㄷ, =, ㅁ, zig-zag)
    [SerializeField] private int [,] map_1 = new int[4, 7];
    [SerializeField] private int [,] map_2 = new int[2, 8];
    [SerializeField] private int [,] map_3 = new int[4, 4];
    [SerializeField] private int [,] map_4 = new int[4, 5];

    void Start()
    {
        Vector3 startPosition = new Vector3(0f, 0f, 0f);

        if (stageNum==1)    CreateStage1(startPosition, map_1);
        else if (stageNum==2)    CreateStage2(startPosition, map_2);
        else if (stageNum==3)    CreateStage3(startPosition, map_3);
        else if (stageNum==4)    CreateStage4(startPosition, map_4);

    }

    void CreateTongBoat(Vector3 pos)
    {
        GameObject clone = Instantiate(stumpPrefab, pos, Quaternion.identity);
        clone.transform.Rotate(60f, 0f, 0f);
        // Create Parent of clones
        clone.transform.parent = GameObject.Find("Stumps").transform;

        Stump stump = clone.GetComponent<Stump>();
        int num = Random.Range(0,4);
        stump.ChangeType(num);
    }

    void CreateStage1(Vector3 pos, int[,] map)
    {
        int row=4, col=7;
        // create map array
        for (int r=0; r<row; r++)
        {
            map[r,0] = 1;
            for (int c=1; c<col; c++)
            {
                if (r==0 || r==3)
                    map[r,c] = 1;
                else
                    map[r,c] = 0;
            }
        }
        // create object
        for (int r=0; r<row; r++)
        {
            for (int c=0; c<col; c++)
            {
                if (count == 0)   break;
                else if (map[r,c] == 1) 
                {
                    CreateTongBoat(pos + new Vector3(c%col * 1.3f, -r%row * 1.0f, 0f));
                    count--;
                }
            }
        }
    }

    void CreateStage2(Vector3 pos, int[,] map)
    {
        int row=2, col=8;
        // create map array
        for (int r=0; r<row; r++)
        {
            for (int c=0; c<col; c++)
                map[r,c] = 1;
        }
        // create object
        for (int r=0; r<row; r++)
        {
            for (int c=0; c<col; c++)
            {
                if (count == 0) break;
                else if (map[r,c] == 1)
                {
                    CreateTongBoat(pos + new Vector3(c%col * 1.3f, -r%row * 1.0f, 0f));
                    count--;
                }
            }
        }
    }

    void CreateStage3(Vector3 pos, int[,] map)
    {
        int row=4, col=4;
        // create map array
        for (int r=0; r<row; r++)
        {
            for (int c=0; c<col; c++)
                map[r,c] = 1;
        }
        // create object
        for (int r=0; r<row; r++)
        {
            for (int c=0; c<col; c++)
            {
                if (count == 0) break;
                else if (map[r,c] == 1)
                {
                    CreateTongBoat(pos + new Vector3(c%col * 1.3f, -r%row * 1.0f, 0f));
                    count--;
                }
            }
        }
    }

    void CreateStage4(Vector3 pos, int[,] map)
    {
        int row=4, col=5;
        // create map array
        for (int r=0; r<row; r++)
        {
            for (int c=0; c<col; c++)
                map[r,c] = 1;
        }
        // create object
        for (int r=0; r<row; r++)
        {
            for (int c=0; c<col; c++)
            {
                if (count == 0) break;
                else if (map[r,c] == 1)
                {
                    CreateTongBoat(pos + new Vector3(c%col * 1.3f, -r%row * 1.0f, 0f));
                    count--;
                }
            }
        }
    }


}


// { {1, 1, 1, 1, 1, 1, 1},
//   {1, 0, 0, 0, 0, 0, 0},
//   {1, 0, 0, 0, 0, 0, 0},
//   {1, 1, 1, 1, 1, 1, 1} };


// { {1, 1, 1, 1, 0},
//   {0, 1, 1, 1, 1},
//   {1, 1, 1, 1, 0},
//   {0, 1, 1, 1, 1} };

