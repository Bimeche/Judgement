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

		if (active) {
			stopMoving = true;
			enableBox ();
		} else {
			disableBox ();
		}
	}

	public void ImportDialog(string[] dial)
	{
		textLines = dial;
		
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
		Debug.Log(textLines.Length);
		theText.text = textLines [currentLine];
		if(currentLine == 0 && var)
		{
			var = false;
		}else if (Input.GetKeyDown (KeyCode.Space) && !var) 
		{
			currentLine++;
		}

		if (currentLine > endAtLine) 
		{
			disableBox ();
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

	public void disableBox()
	{
		textBox.SetActive (false);
		active = false;
		Debug.Log("hfeuerverfhkerjbfhjbfhkvberhjkfbeskjhfbskjhfbkjhdsrvbfhkjdrs bfhkjersbvfhkjversbfjhkbsdkrjgfvbshkjebfhkjebfrkuebfrhkjverbkuyhb");
		currentLine = 0;
		var = true;
		//if(playerCame)
			//Destroy (textBox);

		stopMoving = false;
		player.canMove = true;
	}



}
