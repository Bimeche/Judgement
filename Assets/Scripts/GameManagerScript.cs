using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public MapGenerator mg;
    public Camera cam;
    public Transform hero;
    private Transform instance;

	// Use this for initialization
	void Start () {
        mg.MapSetup();
        instance = UnityEngine.Object.Instantiate(hero, new Vector3(450, 50, 0f), Quaternion.identity) as Transform;
	}

    void Awake()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
