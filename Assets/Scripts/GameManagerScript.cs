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

    private Vector2[] pnjPos;

	// Use this for initialization
	void Start () {
        pnjPos = new Vector2[9];
        pnjPos = mg.MapSetup();
        /*for (int i = 0; i < pnjPos.Length; i++)
        {
            Debug.Log("Pos" + i + ": " + pnjPos[i].ToString());
        }*/
        for (int i = 0; i < pnjs.Length; i++)
        {
            pnjs[i].transform.Translate (pnjPos[i].x,pnjPos[i].y,0f);
        }
        minuteLeft = 5;
        secondLeft = 0;
        msecondLeft = 0;
        TotalPlace = 2;
}

    void Awake()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if (FindObjectOfType<PlayerController>().getPassenger() >= TotalPlace)
        {
            GameOver();
        }
        else
        {
            placeText.text = "Nb Place: " + FindObjectOfType<PlayerController>().getPassenger().ToString() + "/" + TotalPlace.ToString();

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
