using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

    public MapGenerator mg;
    public Camera cam;
    public Transform hero;//The hero prefab
    public Transform pnj;//The pnj prefab
    public NPC[] pnjs;//Created pnjs

    public Canvas canvas;
    public TextBoxManager txtBox;
    public GameObject assocText;

    private Transform instanceHero;

	// Use this for initialization
	void Start () {
        mg.MapSetup();
       /* instanceHero = UnityEngine.Object.Instantiate(hero, new Vector3(450, 50, 0f), Quaternion.identity) as Transform;
        UnityEngine.Object.Instantiate(assocText);
        pnjs = new NPC[3];
        /*for (int i = 0; i < 3; i++)
         {
            Debug.Log("I: " + i);
            pnjs[i] = UnityEngine.Object.Instantiate(pnj, new Vector3(i*50, 50, 0f), Quaternion.identity) as NPC;
         }*/
    }

    void Awake()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
