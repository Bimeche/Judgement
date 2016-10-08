using UnityEngine;
using System.Collections;
using System;

public class NPC : InteractiveObject {

    //     public TextBoxManager m_textBoxManager;
    public string[] dialogs;
    public bool reveal;
    // Use this for initialization
    public void Start()
    {
        throw new NotImplementedException();
        // Set a personality
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
	    
	}

    public override void interact()
    {
        // dialogue

        throw new NotImplementedException();
    }
}
