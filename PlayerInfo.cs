using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BasicStats
{
    public float maxHP, nowHP, maxMP, nowMP, maxEXP, nowEXP;

    public Text HPtext, MPtext, EXPtext;

    public Image HPbar, MPbar, EXPbar, playerimage;
}

public class PlayerInfo : MonoBehaviour
{
    [SerializeField]
    public BasicStats bs;

    void Update()
    {
        bs.HPtext.text = bs.nowHP + " / " + bs.maxHP;
        bs.MPtext.text = bs.nowMP + " / " + bs.maxMP;
        bs.EXPtext.text = bs.nowEXP + " / " + bs.maxEXP;

        bs.HPbar.fillAmount = bs.nowHP / bs.maxHP;
        bs.MPbar.fillAmount = bs.nowMP / bs.maxMP;
        bs.EXPbar.fillAmount = bs.nowEXP / bs.maxEXP;
    }

    void setmaxHP(int temp)
    {
        bs.maxHP = temp;
    }
    void setnowHP(int temp)
    {
        bs.nowHP = temp;
    }
    void setmaxMP(int temp)
    {
        bs.maxMP = temp;
    }
    void setnowMP(int temp)
    {
        bs.nowMP = temp;
    }
    void setmaxEXP(int temp)
    {
        bs.maxEXP = temp;
    }
    void setnowEXP(int temp)
    {
        bs.nowEXP = temp;
    }


}
