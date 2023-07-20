using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Moving
{
    public Animator animator;
    public BoxCollider2D boxcollider;
    public LayerMask layermask;
    public bool dontmove = false, invenopen = false;

    IEnumerator Movecoroutine()
    {
        while (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if (vector.x != 0)
            {
                vector.y = 0;
            }
            animator.SetFloat("DirX", vector.x);
            animator.SetFloat("DirY", vector.y);

            RaycastHit2D hit;

            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(vector.x * speed * walkcount, vector.y * speed * walkcount);
            
            boxcollider.enabled = false;
            hit = Physics2D.Linecast(start, end, layermask);
            boxcollider.enabled = true;

            if (hit.transform != null)
            {
                break;
            }

            if (dontmove)
            {
                break;
            }

            animator.SetBool("Walking", true);

            while (currentwalkcount < walkcount)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x * speed, 0, 0);

                }
                if (vector.y != 0)
                {
                    transform.Translate(0, vector.y * speed, 0);
                }
                currentwalkcount++;
                yield return new WaitForSeconds(0.01f);
            }
            currentwalkcount = 0;
        }
        canmove = true;
        animator.SetBool("Walking", false);
    }

    void Update()
    {
        if (canmove && !dontmove && !invenopen)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                    canmove = false;
                    StartCoroutine(Movecoroutine());
            }
        }
    }
}
