using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normaldialogue : MonoBehaviour
{
    public Dialogue dialogue;

    private Dialoguemanager thedm;
    private bool block = true;

    void Start()
    {
        thedm = FindObjectOfType<Dialoguemanager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !block)
        {
            thedm.Showdialogue(dialogue);
            block = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        block = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        block = true;
    }
}
