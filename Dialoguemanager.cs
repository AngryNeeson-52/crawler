using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialoguemanager : MonoBehaviour
{
    public Text text;
    public SpriteRenderer rendererdialogueplate;

    private List<string> listsentences;
    private List<Sprite> listdialogueplates;
    private PlayerMove theplayer;

    private int count;

    public Animator animedialogueplate;

    public bool talking = false;

    private bool keyactivated = false;

    void Start()
    {
        count = 0;
        text.text = "";
        listsentences = new List<string>();
        listdialogueplates = new List<Sprite>();
        theplayer = FindObjectOfType<PlayerMove>();
    }

    public void Showdialogue(Dialogue dialogue)
    {
        theplayer.dontmove = true;
        talking = true;

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            listsentences.Add(dialogue.sentences[i]);
            listdialogueplates.Add(dialogue.dialogueplates[i]);
        }
        animedialogueplate.SetBool("Appear", true);
        StartCoroutine(Startdialoguecoroutine());
    }

    public void Exitdialogue()
    {
        text.text = "";
        count = 0;
        listsentences.Clear();
        listdialogueplates.Clear();
        animedialogueplate.SetBool("Appear", false);
        talking = false;
    }

    IEnumerator Startdialoguecoroutine()
    {
        if (count > 0)
        {
            if (listdialogueplates[count] != listdialogueplates[count - 1])
            {
                animedialogueplate.SetBool("Appear", false);
                yield return new WaitForSeconds(0.2f);
                rendererdialogueplate.GetComponent<SpriteRenderer>().sprite = listdialogueplates[count];
                animedialogueplate.SetBool("Appear", true);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.05f);
            rendererdialogueplate.GetComponent<SpriteRenderer>().sprite = listdialogueplates[count];
        }


        for (int i = 0; i < listsentences[count].Length; i++)
        {
            text.text += listsentences[count][i];
            if (i % 2 == 1)
            yield return new WaitForSeconds(0.01f);
        }

        keyactivated = true;
    }

    void Update()
    {
        if (talking && keyactivated)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                keyactivated = false;
                count++;
                text.text = "";
                if (count == listsentences.Count)
                {
                    StopAllCoroutines();
                    Exitdialogue();
                    theplayer.dontmove = false;
                }
                else
                {
                    StopAllCoroutines();
                    StartCoroutine(Startdialoguecoroutine());
                }
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                StopAllCoroutines();
                Exitdialogue();
                theplayer.dontmove = false;
            }
        }
    }
}
