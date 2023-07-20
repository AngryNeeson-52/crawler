using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private PlayerMove playermove;

    private bool invenactivated = false;
    private bool menuselect = true, itemselect = false;

    private int selectedmenu;
    private int selectedslots;

    [SerializeField]
    private GameObject inven;
    [SerializeField]
    private Text describetext;
    [SerializeField]
    private GameObject[] menu;
    [SerializeField]
    private string[] menudescription;

    private WaitForSeconds waittime = new WaitForSeconds(0.01f);

    void Start()
    {
        playermove = FindObjectOfType<PlayerMove>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !playermove.dontmove)
        {
            if (!invenactivated)
            {
                selectedmenu = 0;
                selectedslots = 0;
                describetext.text = menudescription[selectedmenu];
                StartCoroutine(SelectedCoroutine());
                playermove.invenopen = true;
                inven.SetActive(true);
                invenactivated = true;
            }
            else 
            {

                inven.SetActive(false);
                invenactivated = false;
                playermove.invenopen = false;
            }
        }

        if (invenactivated)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (menuselect)
                {
                    inven.SetActive(false);
                    invenactivated = false;
                    playermove.invenopen = false;
                }
                else if(itemselect)
                {
                    menuselect = true;
                    itemselect = false;
                    StartCoroutine(SelectedCoroutine());
                }
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (menuselect)
                {
                    NotSelected(0.5f);

                    menuselect = false;
                    itemselect = true;

                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (menuselect)
                {

                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (menuselect)
                {
                    NotSelected(1.0f);

                    if (selectedmenu > 0)
                    {
                        selectedmenu--;
                    }
                    else
                    {
                        selectedmenu = menu.Length - 1;
                    }

                    StartCoroutine(SelectedCoroutine());
                    describetext.text = menudescription[selectedmenu];
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (menuselect)
                {
                    NotSelected(1.0f);

                    if (selectedmenu < menu.Length - 1)
                    {

                        selectedmenu++;
                    }
                    else 
                    {
                        selectedmenu = 0;
                    }

                    StartCoroutine(SelectedCoroutine());
                    describetext.text = menudescription[selectedmenu];
                }
            }
        }
    }

    void NotSelected(float a)
    {
        StopAllCoroutines();
        Color color = menu[selectedmenu].GetComponent<Image>().color;
        color.a = a;
        menu[selectedmenu].GetComponent<Image>().color = color;
    }

    IEnumerator SelectedCoroutine()
    {
        while (menuselect)
        {
            Color color = menu[selectedmenu].GetComponent<Image>().color;
            while (color.a < 1.0f)
            {
                color.a += 0.03f;
                menu[selectedmenu].GetComponent<Image>().color = color;
                yield return waittime;
            }
            while (color.a > 0.1f)
            {
                color.a -= 0.03f;
                menu[selectedmenu].GetComponent<Image>().color = color;
                yield return waittime;
            }
        }

        yield return new WaitForSeconds(0.3f);
    }

}
