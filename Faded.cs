using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faded : MonoBehaviour
{
    public SpriteRenderer black;

    private Color color;

    private WaitForSeconds waittime = new WaitForSeconds(0.01f);

    public void Fadeout(float _speed = 0.02f)
    {
        StartCoroutine(Fadeoutcoroutine(_speed));
    }
    IEnumerator Fadeoutcoroutine(float _speed)
    {
        color = black.color;

        while (color.a < 1f)
        {
            color.a += _speed;
            black.color = color;
            yield return waittime;
        }
    }
    public void Fadein(float _speed = 0.02f)
    {
        StartCoroutine(Fadeincoroutine(_speed));
    }
    IEnumerator Fadeincoroutine(float _speed)
    {
        color = black.color;

        while (color.a > 0f)
        {
            color.a -= _speed;
            black.color = color;
            yield return waittime;
        }
    }
    public void DARK()
    {
        color = black.color;
        color.a = 1f;
        black.color = color;
    }
}
