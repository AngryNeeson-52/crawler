using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AntMove : Moving
{
    public Queue<string> queue;

    private bool notcoroutine = false;
    public Animator animator;
    public BoxCollider2D boxcollider;
    public LayerMask layermask;

    void Start()
    {
        queue = new Queue<string>();
        if (npc.npcmove)
        {
            StartCoroutine(Ordercoroutine());
        }
    }
    public void Move(string _dir, int _frequency = 5)
    {
        queue.Enqueue(_dir);
        if (!notcoroutine)
        {
            notcoroutine = true;
            StartCoroutine(Movecoroutine(_dir, _frequency));
        }
    }

    IEnumerator Movecoroutine(string _dir, int _frequency)
    {
        while (queue.Count != 0)
        {
            switch (_frequency)
            {
                case 1:
                    yield return new WaitForSeconds(4f);
                    break;
                case 2:
                    yield return new WaitForSeconds(3f);
                    break;
                case 3:
                    yield return new WaitForSeconds(2f);
                    break;
                case 4:
                    yield return new WaitForSeconds(1f);
                    break;
                case 5:
                    break;
            }

            string direction = queue.Dequeue();
            vector.Set(0, 0, vector.z);

            switch (direction)
            {
                case "UP":
                    vector.y = 1f;
                    break;
                case "DOWN":
                    vector.y = -1f;
                    break;
                case "LEFT":
                    vector.x = -1f;
                    break;
                case "RIGHT":
                    vector.x = 1f;
                    break;
            }

            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);

            while (true)
            {
                bool checkcollsionflag = CheckCollsion();
                if (checkcollsionflag)
                {
                    animator.SetBool("AntWalking", false);
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    break;
                }
            }

            animator.SetBool("AntWalking", true);

            boxcollider.offset = new Vector2(vector.x * 0.7f * speed * walkcount, vector.y * 0.7f * speed * walkcount);

            while (currentwalkcount < walkcount)
            {
                transform.Translate(vector.x * speed, vector.y * speed, 0);
                currentwalkcount++;
                if (currentwalkcount == 12)
                    boxcollider.offset = Vector2.zero;
                yield return new WaitForSeconds(0.01f);
            }
            currentwalkcount = 0;

            if (_frequency != 5)
            {
                animator.SetBool("AntWalking", false);
            }
        }
        animator.SetBool("AntWalking", false);
        notcoroutine = false;
    }

    IEnumerator Ordercoroutine()
    {
        if (npc.direction.Length != 0)
        {
            for (int i = 0; i < npc.direction.Length; i++)
            {
                yield return new WaitUntil(() => queue.Count < 2);

                Move(npc.direction[i], npc.frequency);

                if (i == npc.direction.Length - 1)
                {
                    i = -1;
                }
            }
        }
    }
    protected bool CheckCollsion()
    {
        RaycastHit2D hit;
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(vector.x * speed * walkcount, vector.y * speed * walkcount);

        boxcollider.enabled = false;
        hit = Physics2D.Linecast(start, end, layermask);
        boxcollider.enabled = true;

        if (hit.transform != null)
        {
            return true;
        }
        return false;
    }
}
