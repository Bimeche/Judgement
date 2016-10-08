using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    private int size = 3;
    private Transform MapHolder;
    public GameObject[] tiles;

    void MapSetup()
    {
        MapHolder = new GameObject("Map").transform;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                GameObject toInstantiate = tiles[Random.Range(0, tiles.Length)];
                GameObject instance = UnityEngine.Object.Instantiate(toInstantiate, new Vector3(x*10.8f,y*10.8f,0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(MapHolder);
            }
        }
    }

    void Awake()
    {
        MapSetup();
    }

}
