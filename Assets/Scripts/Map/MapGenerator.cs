using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour {

    private int size = 3;
    private Transform MapHolder;
    public GameObject[] tiles;
    private Vector2[] posToGo;

    public Vector2[] MapSetup()
    {
        Vector2[] pnjPos = new Vector2[9];
        posToGo = new Vector2[9] {new Vector2(18,-132), new Vector2(-281,43), new Vector2(71,-374), new Vector2(-333,140), new Vector2(-190,266), new Vector2(144,-337), new Vector2(203,-367), new Vector2(-45,365), new Vector2(-263,317)};
        int num;
        bool[] usedtiles = new bool[9] { false, false, false, false, false, false, false, false, false };
        MapHolder = new GameObject("Map").transform;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                num = Random.Range(0, tiles.Length);
                while (usedtiles [num] == true)
                {
                    num = Random.Range(0, tiles.Length);
                }
                usedtiles[num] = true;
                Debug.Log("!!!PosNum " + num + " X: "+ posToGo[num].x + x * 1080f+ " Y: " + posToGo[num].y + y * 1080f);
                pnjPos[num].x = posToGo[num].x+x*1080f;
                pnjPos[num].y = posToGo[num].y + y*1080f;
                GameObject toInstantiate = tiles[num];
                GameObject instance = UnityEngine.Object.Instantiate(toInstantiate, new Vector3(x*1080f,y*1080f,0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(MapHolder);
            }
        }
        return pnjPos;
    }

    void Awake()
    {

    }

}
