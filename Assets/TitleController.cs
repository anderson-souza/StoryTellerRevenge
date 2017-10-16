using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    private Text _movieName;

    void Start()
    {
        if (_movieName == null)
        {
            _movieName = gameObject.GetComponentInChildren<Text>();
        }
    }

    public void ChangeTitle(string title)
    {
        _movieName.text = title;
        FadeInOutCanvas();
    }

    private void FadeInOutCanvas()
    {
        StartCoroutine("FadeInCanvas");
    }

    IEnumerator FadeInCanvas()
    {
        float start = Time.time;
        float elapsed = 0;
        float duration = 1.5f;
        while (elapsed < duration)
        {
            elapsed = Time.time - start;
            float normalisedTime = Mathf.Clamp(elapsed / duration, 0, 1);
            GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, 1, normalisedTime);
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        start = Time.time;
        elapsed = 0;
        while (elapsed < duration)
        {
            elapsed = Time.time - start;
            float normalisedTime = Mathf.Clamp(elapsed / duration, 0, 1);
            GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, normalisedTime);
            yield return null;
        }
    }
}