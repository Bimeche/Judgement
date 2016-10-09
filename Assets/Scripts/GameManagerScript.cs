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
    public GameObject[] pnjs;//Created pnjs

    public Canvas canvas;
    public TextBoxManager txtBox;
    public GameObject assocText;
    public Text timeText;

    public double minuteLeft;
    public double secondLeft;
    public double msecondLeft;

    private int TotalPlace;
    public Text placeText;

    private Transform instanceHero;

    private PlayerController player;

    private Vector2[] pnjPos;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        pnjPos = new Vector2[9];
        pnjPos = mg.MapSetup();
        for (int i = 0; i < pnjs.Length; i++)
        {
            pnjs[i].transform.Translate (pnjPos[i].x,pnjPos[i].y,0f);
        }
        minuteLeft = 2;
        secondLeft = 0;
        msecondLeft = 0;
        TotalPlace = 5;
}

    void Awake()
    {

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("escape")) { 
            Application.Quit(); // Quits the game
        }

            if (player.getPassenger() >= TotalPlace || player.getTalk() == pnjs.Length)
        {
            GameOver();
        }
            placeText.text = "Nb Places: " + player.getPassenger().ToString() + "/" + TotalPlace.ToString();

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
            }
            else if (msecondLeft < 10)
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
        if (player.getGood() > 0 && player.getPassenger()>=2) {
            SceneManager.LoadScene(3);//GoodEnd
        } else
        {
            SceneManager.LoadScene(2);//BadEnd
        }
    }
}
