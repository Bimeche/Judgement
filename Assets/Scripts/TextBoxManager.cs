using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	private string[] textLines;
	public GameObject textBox;
	public Text theText;

	public bool playerCame;
	public int currentLine;
	public int endAtLine;

	public bool active;
	public bool stopMoving;
	public bool var;
	public bool choix;

	public PlayerController player;


    // Use this for initialization
    void Start () {
	
		player = FindObjectOfType<PlayerController> ();

		/*if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}*/
		playerCame = false;
		var = true;
		choix = false;

		if (active) {
			stopMoving = true;
			enableBox ();
		} else {
			disableBox (1);
		}
	}

	public void ImportDialog(string[] dial, bool isHuman)
	{
		textLines = dial;
		if (isHuman) 
		{
			string[] tab = new string[textLines.Length+1];
			textLines.CopyTo(tab, 0);
			textLines = tab;
			textLines [3] = "Sauvez cette personne ?\nOui (appuyer sur O) \nNon (appuyer sur N)";
		}

		
		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}

		enableBox ();
		
	}


	void Update () {

		if (!active) 
		{
			return;
		}
		
		theText.text = textLines [currentLine];
		if (currentLine == 0 && var) {
			var = false;
		} else if (Input.GetKeyDown (KeyCode.Space) && !var) {
			if (currentLine < 3) {
				currentLine++;
			}
		} else if (Input.GetKeyDown (KeyCode.N) && currentLine == 3) 
		{
			choix = false;
			currentLine++;
		} else if (Input.GetKeyDown (KeyCode.O) && currentLine == 3) 
		{
			choix = true;
			currentLine++;
		}

		if (currentLine > endAtLine) 
		{
			disableBox (0);
		}
	}

	public void enableBox()
	{
		textBox.SetActive (true);
		active = true;
		playerCame = true;

		//if (stopMoving) {
			player.canMove = false;
		//}
	}

	public void disableBox( int init)
	{
		textBox.SetActive (false);
		active = false;
		Debug.Log("hfeuerverfhkerjbfhjbfhkvberhjkfbeskjhfbskjhfbkjhdsrvbfhkjdrs bfhkjersbvfhkjversbfjhkbsdkrjgfvbshkjebfhkjebfrkuebfrhkjverbkuyhb");
		currentLine = 0;
		var = true;
		//if(playerCame)
			//Destroy (textBox);
		Debug.Log (choix);	
		stopMoving = false;
        if (init != 1)
        {
            player.canMove = true;
        }
	}



}
