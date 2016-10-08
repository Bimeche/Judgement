using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	private string[] textLines = {"Je suis la","J'ai peur"};
	public GameObject textBox;
	public Text theText;

	public int currentLine;
	public int endAtLine;

	public bool active;
	public bool stopMoving;

	public PlayerController player;
	// Use this for initialization


	void Start () {
	
		player = FindObjectOfType<PlayerController> ();

		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}

		if (active) {
			stopMoving = true;
			enableBox ();
		} else {
			disableBox ();
		}
	}

	public void ImportDialog(string[] dial)
	{
		for (int i = 0; i < dial.Length; i++)
			textLines [i] = dial [i];
		
		//if (endAtLine == 0) 
		//{
		//	endAtLine = textLines.Length - 1;
		//}

		enableBox ();
		
	}


	void Update () {

		if (!active) 
		{
			return;
		}
		theText.text = textLines [currentLine];

		if (Input.GetKeyDown (KeyCode.Space)) 
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

		if (stopMoving) {
			player.canMove = false;
		}
	}

	public void disableBox()
	{
		textBox.SetActive (false);
		active = false;
		Destroy (textBox);

		stopMoving = false;
		player.canMove = true;
	}



}
