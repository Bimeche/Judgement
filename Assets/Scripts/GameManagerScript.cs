using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    public MapGenerator mg;
    public Camera cam;
    public Transform hero;//The hero prefab
    public Transform pnj;//The pnj prefab
    public NPC[] pnjs;//Created pnjs

    public Canvas canvas;
    public TextBoxManager txtBox;
    public GameObject assocText;
    public Text timeText;

    public double minuteLeft = 5;
    public double secondLeft = 0;
    public double msecondLeft = 0;

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
        if (msecondLeft <= 0)
        {
            if (secondLeft <= 0)
            {
                if (minuteLeft <= 0)
                {
                    GameOver();
                }
                else
                {
                    msecondLeft = 59;
                    secondLeft = 59;
                    minuteLeft -= 1;
                }
            }
            else
            {
                msecondLeft = 59;
                secondLeft -= 1;
            }
        }else if(msecondLeft < 10)
        {
            msecondLeft -= 1;
            timeText.text = "Temps restant: " + minuteLeft + ":" + secondLeft + ":0" + msecondLeft;
        }
        else
        {
            msecondLeft -= 1;
            timeText.text = "Temps restant: " + minuteLeft + ":" + secondLeft + ":" + msecondLeft;
        }
    }

    void GameOver()
    {
        if (FindObjectOfType<PlayerController>().getGood() > 0) {
            SceneManager.LoadScene(3);//GoodEnd
        } else
        {
            SceneManager.LoadScene(2);//BadEnd
        }
    }
}
