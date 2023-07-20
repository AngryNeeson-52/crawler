using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform target;
    private PlayerMove theplayer;
    private Cameramanager thecamera;

    public BoxCollider2D targetbound;

    private Faded thefade;

    private bool check = true;
    void Start()
    {
        thecamera = FindObjectOfType<Cameramanager>();
        theplayer = FindObjectOfType<PlayerMove>();
        thefade = FindObjectOfType<Faded>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (check)
        {
            check = false;
            StartCoroutine(Transfercoroutine());
        }

    }
    IEnumerator Transfercoroutine()
    {
        theplayer.dontmove = true;

        thefade.Fadeout();

        yield return new WaitForSeconds(1f);
        thecamera.SetBound(targetbound);
        thecamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, thecamera.transform.position.z);
        theplayer.transform.position = target.transform.position;
        thefade.Fadein();
        yield return new WaitForSeconds(1f);
        theplayer.dontmove = false;
        check = true;
    }
}
