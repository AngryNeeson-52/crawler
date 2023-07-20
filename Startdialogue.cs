using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startdialogue : MonoBehaviour
{
    public Dialogue dialogue;

    private Dialoguemanager thedm;
    private bool block = true;
    private Faded faded;

    void Start()
    {
        thedm = FindObjectOfType<Dialoguemanager>();
        faded = FindObjectOfType<Faded>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {               
            if (block)
            {
                faded.DARK();
                block = false;
                thedm.Showdialogue(dialogue);
            }
            if (!thedm.talking)
            {
                faded.Fadein();
            }
        }
    }
}
