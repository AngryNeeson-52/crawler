using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Npcmove
{
    public bool npcmove;

    public string[] direction;

    [Range(1, 5)]
    public int frequency;
}

public class Moving : MonoBehaviour
{
    [SerializeField]
    public Npcmove npc;

    public float speed;
    public int walkcount;
    public bool canmove = true;
    protected int currentwalkcount = 0;
    protected Vector3 vector;
}
