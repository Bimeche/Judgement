using UnityEngine;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour {

    private int size = 3;
    private Transform MapHolder;
    public GameObject[] tiles;

    void MapSetup()
    {
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
                GameObject toInstantiate = tiles[num];
                GameObject instance = UnityEngine.Object.Instantiate(toInstantiate, new Vector3(x*1080f,y*1080f,0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(MapHolder);
            }
        }
    }

    void Awake()
    {
        MapSetup();
    }

}
