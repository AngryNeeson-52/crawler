using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text start;
    public Text load;
    public Text end;

    private int result;

    private Sound sound;

    void Start()
    {
        start.fontStyle = FontStyle.Bold;
        result = 0;
        sound = FindObjectOfType<Sound>();
    }

    void Selectmenu()
    {
        if (result == 0)
        {
            start.fontStyle = FontStyle.Bold;
            load.fontStyle = FontStyle.Normal;
            end.fontStyle = FontStyle.Normal;
        }
        else if (result == 1)
        {
            start.fontStyle = FontStyle.Normal;
            load.fontStyle = FontStyle.Bold;
            end.fontStyle = FontStyle.Normal;
        }
        else if (result == 2)
        {
            start.fontStyle = FontStyle.Normal;
            load.fontStyle = FontStyle.Normal;
            end.fontStyle = FontStyle.Bold;
        }
    }

    void Resultupdown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (result == 0)
            {
                result = 2;
                sound.Play("menusound");
            }
            else
            {
                result--;
                sound.Play("menusound");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (result == 2)
            {
                result = 0;
                sound.Play("menusound");
            }
            else
            {
                result++;
                sound.Play("menusound");
            }
        }
    }

    void Update()
    {

        Selectmenu();

        Resultupdown();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (result == 0)
            {
                SceneManager.LoadScene("MainScene");
            }
            else if (result == 1)
            {

            }
            else if (result == 2)
            {
                Application.Quit();
            }
        }
    }
}
