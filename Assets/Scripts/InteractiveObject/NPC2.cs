﻿using UnityEngine;
using System.Collections;
//using System;

public class NPC2 : InteractiveObject {

	public TextBoxManager m_textBox;
	public string[] dialogs;
	public bool reveal;
	public int okay;
	public AssociateTextNPC assosText;

	// Use this for initialization
	public void Start()
	{
		okay = 0;
		int type = Random.Range (1, 4);
		dialogs = assosText.GenerateDial (type);
		Debug.Log (type);
	}

	void SetNPC(string[] dials, bool rev)
	{
		reveal = rev;
		dialogs = dials;
	}

	public void SetReveal(bool val)
	{
		reveal = val;
	}

	public bool GetReveal()
	{
		return reveal;
	}

	internal void SetRenderer(bool v)
	{
		GetComponent<Renderer>().enabled = v;
	}

	// Update is called once per frame
	public void Update () {
		if (okay == 1)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				m_textBox.ImportDialog(dialogs,true);
				okay = 2;
			}
		}
	}

	public override void Interact()
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(okay !=2)
			okay = 1;
	}
}
