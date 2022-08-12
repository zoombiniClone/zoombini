using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongBoatScript : MonoBehaviour
{
    enum Stage
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4
    };

    // Making stump map
    [SerializeField] private GameObject stumpPrefab;
    [SerializeField] private int count = 16;
    [SerializeField] private Stage stage = Stage.Stage1;  // stage : 1~4 (ㄷ, =, ㅁ, zig-zag)

    private Transform stumpParentTransform;
    private int [,] map_1 = new int[4, 7];
    private int [,] map_2 = new int[2, 8];
    private int [,] map_3 = new int[4, 4];
    private int [,] map_4 = new int[4, 5];

    void Start()
    {
        Vector3 startPosition = new Vector3(0f, 0f, 0f);
        stumpParentTransform = GameObject.Find("Stumps").transform;

        switch (stage)
        {
            case Stage.Stage1:
                CreateStage1(startPosition, map_1);
                break;
            case Stage.Stage2:
                CreateStage2(startPosition, map_2);
                break;
            case Stage.Stage3:
                CreateStage3(startPosition, map_3);
                break;
            case Stage.Stage4:
                CreateStage4(startPosition, map_4);
                break;
            default:
                break;
        }
    }

    GameObject CreateTongBoat(Vector3 pos)
    {
        GameObject clone = Instantiate(stumpPrefab, pos, Quaternion.identity);
        clone.transform.Rotate(60f, 0f, 0f);
        // Create Parent of clones
        clone.transform.parent = stumpParentTransform;

        return clone;
    }

    void CreateStage1(Vector3 pos, int[,] map)
    {
        int row=4, col=7;

        GameObject[,] tongBoatsMap = new GameObject[4, 7];
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
                if (count == 0) break;
                else if (map[r, c] == 1) 
                {
                    tongBoatsMap[r, c] = CreateTongBoat(pos + new Vector3(c%col * 1.3f, -r%row * 1.0f, 0f));
                    count--;
                }
            }
        }

        for (int c=0; c<col; c++)
        {
            if (c < col - 1)
            {
                tongBoatsMap[0, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[0, c + 1].GetComponent<StumpScript>());
                tongBoatsMap[3, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[3, c + 1].GetComponent<StumpScript>());
            }
            if (c > 0)
            {
                tongBoatsMap[0, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[0, c - 1].GetComponent<StumpScript>());
                tongBoatsMap[3, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[3, c - 1].GetComponent<StumpScript>());
            }
        }
        for (int r=0; r<row; r++)
        {
            if (r > 0)
                tongBoatsMap[r, 0].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r - 1, 0].GetComponent<StumpScript>());
            if (r < row - 1)
                tongBoatsMap[r, 0].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r + 1, 0].GetComponent<StumpScript>());
        }

    }

    void CreateStage2(Vector3 pos, int[,] map)
    {
        int row=2, col=8;
        GameObject[,] tongBoatsMap = new GameObject[2, 8];
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
                    tongBoatsMap[r, c] = CreateTongBoat(pos + new Vector3(c%col * 1.3f, -r%row * 1.0f, 0f));
                    count--;
                }
            }
        }

        for (int r=0; r<row; r++) 
        {
            for (int c=0; c<col; c++) 
            {
                if (r == 0) 
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r+1, c].GetComponent<StumpScript>());
                else
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r-1, c].GetComponent<StumpScript>());

                if (c != 0) 
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r, c-1].GetComponent<StumpScript>());

                if (c != col-1) 
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r, c+1].GetComponent<StumpScript>());
            }
        }
    }

    void CreateStage3(Vector3 pos, int[,] map)
    {
        int row=4, col=4;
        GameObject[,] tongBoatsMap = new GameObject[4, 4];
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
                    tongBoatsMap[r, c] = CreateTongBoat(pos + new Vector3(c%col * 1.3f, -r%row * 1.0f, 0f));
                    count--;
                }
            }
        }

        for (int r=0; r<row; r++) 
        {
            for (int c=0; c<col; c++) 
            {
                if (r != 0) 
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r-1, c].GetComponent<StumpScript>());
                if (r != row-1)
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r+1, c].GetComponent<StumpScript>());

                if (c != 0) 
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r, c-1].GetComponent<StumpScript>());
                if (c != col-1) 
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r, c+1].GetComponent<StumpScript>());
            }
        }
    }

    void CreateStage4(Vector3 pos, int[,] map)
    {
        int row=4, col=5;
        GameObject[,] tongBoatsMap = new GameObject[4, 5];
        // create map array
        for (int r=0; r<row; r++)
        {
            for (int c=0; c<col; c++)
            {
                map[r, c] = 1;
                if (r % 2 == 0) 
                {
                    if (c == col-1)
                        map[r, c] = 0;
                }
                else
                    if (c == 0)
                        map[r, c] = 0;
            }
        }
        // create object
        for (int r=0; r<row; r++)
        {
            for (int c=0; c<col; c++)
            {
                if (count == 0) break;
                else if (map[r,c] == 1)
                {
                    if (r % 2 == 0)
                        tongBoatsMap[r, c] = CreateTongBoat(pos + new Vector3(c % col * 1.3f, -r % row * 1.0f, 0f));
                    else
                        tongBoatsMap[r, c] = CreateTongBoat(pos + new Vector3(c % col * 1.3f - 0.7f, -r % row * 1.0f, 0f));
                    count--;
                }
            }
        }
        
        
        for (int r=0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                if (c != 0 && map[r, c - 1] == 1 && map[r,c] == 1)   // [r,c-1] - [r,c] : col back
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r, c - 1].GetComponent<StumpScript>());

                if (c != col - 1 && map[r, c + 1] == 1 && map[r, c] == 1) // [r,c] - [r,c+1] : col forward
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r, c + 1].GetComponent<StumpScript>());

                if (r % 2 == 0) // 0,2 : row up&down
                {
                    if (r > 0 && map[r - 1, c] == 1 && map[r, c] == 1)
                        tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r - 1, c].GetComponent<StumpScript>());

                    if (r < row - 2 && map[r + 1, c] == 1 && map[r, c] == 1)
                        tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r + 1, c].GetComponent<StumpScript>());
                }
                else   // 1,3 : row up&down
                {
                    if (r > 1 && map[r - 1, c] == 1 && map[r, c] == 1)
                        tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r - 1, c].GetComponent<StumpScript>());

                    if (r < row - 1 && map[r + 1, c] == 1 && map[r, c] == 1)
                        tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r + 1, c].GetComponent<StumpScript>());
                }

                if (r == 0 && map[r, c] == 1)   // diag
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[1, c + 1].GetComponent<StumpScript>());
                if (r == 1 && map[r, c] == 1)
                {
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r - 1, c - 1].GetComponent<StumpScript>());
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r + 1, c - 1].GetComponent<StumpScript>());
                }
                if (r == 2 && map[r, c] == 1)
                {
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r - 1, c + 1].GetComponent<StumpScript>());
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r + 1, c + 1].GetComponent<StumpScript>());
                }
                if (r == 3 && map[r, c] == 1)
                    tongBoatsMap[r, c].GetComponent<StumpScript>().AddLinkedStump(tongBoatsMap[r - 1, c - 1].GetComponent<StumpScript>());
                

            }
        }
    }
}
