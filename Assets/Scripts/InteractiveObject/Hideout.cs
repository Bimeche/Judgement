using UnityEngine;
using System.Collections;
using System;

public class Hideout : InteractiveObject {

    public NPC hideNPC;
    public bool reveal;

    // Use this for initialization
    public void Start()
    {
        reveal = false;        
        // Create a new NPC ?
    }

    // Update is called once per frame
    public void Update () {
        if (reveal)
        {
            // Remove this object, change for a NPC in hideNPC
        }
	}

    public override void interact()
    {
        // Message, NPC trouvé
        if (hideNPC != null)
        {
            // Coucou !
            reveal = true;
        }
    }

    public void setHideNPC(NPC npc)
    {
        hideNPC = npc;
    }
}
