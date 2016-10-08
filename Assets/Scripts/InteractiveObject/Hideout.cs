using UnityEngine;
using System.Collections;
using System;

public class Hideout : InteractiveObject {

    public NPC m_hideNPC;
    //public TextBoxManager textbox;

//     public TextBoxManager m_textBoxManager;

    // Use this for initialization
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update () {
        if (m_hideNPC.GetReveal())
        {
            m_hideNPC.transform.position = transform.position;
            m_hideNPC.SetRenderer(true);
            GetComponent<Renderer>().enabled = false;
        } else
        {
            m_hideNPC.SetRenderer(false);
            GetComponent<Renderer>().enabled = true;
        }
	}

    public override void interact()
    {
        // Message, NPC trouvé
        if (m_hideNPC != null)
        {
            m_hideNPC.SetReveal(true);
        } else {
            string[] array = { "Il n'y a personne ici." };
            //textbox.importDialog(array);
        }
    }

    public void setHideNPC(NPC npc)
    {
        m_hideNPC = npc;
        m_hideNPC.SetReveal(false);
    }
}
