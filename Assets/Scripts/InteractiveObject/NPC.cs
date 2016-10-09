using UnityEngine;
using System.Collections;
//using System;

public class NPC : InteractiveObject {

    public TextBoxManager m_textBox;
	public string[] dialogs;
    public bool reveal;
	public int okay;
	public AssociateTextNPC assosText;
	int type;
	public PlayerController player;

    private GameObject currentTarget;

    // Use this for initialization
    public void Start()
    {
        m_textBox = FindObjectOfType<TextBoxManager>();
        assosText = FindObjectOfType<AssociateTextNPC>();
		player = FindObjectOfType<PlayerController>();
        okay = 0;
		type= Random.Range (1, 4);
		dialogs = assosText.GenerateDial (type);

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
                m_textBox.setCurentLine();
				m_textBox.ImportDialog(dialogs,true);
				okay = 2;
               
			}
		}
        
        if (m_textBox.choix)
        {
            //currentTarget.SetActive(false);
            currentTarget.GetComponent<BoxCollider2D>().enabled = false;
            currentTarget.GetComponent<Renderer>().enabled=false;
           
            m_textBox.choix = false;
            if (type == 1)
                player.setGood(10);
            if (type == 2)
                player.setGood(5);
            if (type == 3)
                player.setGood(-10);
            if (type == 4)
                player.setGood(-5);

            player.addTalk();
        }


    }

    public override void Interact()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(okay !=2)
			okay = 1;
        currentTarget = this.gameObject;
        Debug.Log("Enter: " + currentTarget);
        //currentTarget = GetComponent<Renderer>().gameObject;

    }

    

    void OnTriggerExit2D(Collider2D other)
    {
       if (okay != 2)
        {
            Debug.Log("Exit!");
            okay = 0;
        }
        currentTarget = null;
        m_textBox.setCurentLine();
    }

    public void setTextBox(TextBoxManager txtBox)
    {
        this.m_textBox = txtBox;
    }

    public void setAssocTxt(AssociateTextNPC assosTxt)
    {
        this.assosText = assosTxt;
    }

}
