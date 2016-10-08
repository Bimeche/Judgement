using UnityEngine;
using System.Collections;
using System;

public class Hideout : InteractiveObject {

    public NPC m_hideNPC;
    public bool m_reveal;

//     public TextBoxManager m_textBoxManager;

    // Use this for initialization
    public void Start()
    {
        m_reveal = false;        
        // Create a new NPC ?
    }

    // Update is called once per frame
    public void Update () {
        if (m_reveal)
        {
            // Remove this object, change for a NPC in hideNPC
        }
	}

    public override void interact()
    {
        // Message, NPC trouvé
        if (m_hideNPC != null)
        {
            // Coucou !
            m_reveal = true;
        }
    }

    public void setHideNPC(NPC npc)
    {
        m_hideNPC = npc;
    }
}
