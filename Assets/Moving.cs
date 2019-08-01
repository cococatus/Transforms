using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    public Transform[] btnContents;
    private ScrollRect scrollview;
    private Vector3[] corners = new Vector3[4];
    void Start()
    {
        scrollview = GetComponent<ScrollRect>();
        scrollview.onValueChanged.AddListener(onValueChanged);
    }

    void onValueChanged(Vector2 args)
    {
        //пивот влияет
        var contentLocalPos = scrollview.transform.InverseTransformPoint(scrollview.content.position);
        var childLocalPos = scrollview.transform.InverseTransformPoint(scrollview.content.GetChild(0).position);
        //Debug.Log("contentLocalPos " + contentLocalPos + " childLocalPos " + childLocalPos);

        //пивот не влияет
        //scrollview.content.GetLocalCorners(corners);
        //scrollview.content.GetWorldCorners(corners);
        //foreach (var corner in corners)
        //{
        //    Debug.Log(corner);
        //}
        var locPos = btnContents[0].localPosition;
        btnContents[0].localPosition = new Vector3(locPos.x, -contentLocalPos.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        var scrollviewRectTransform = GetComponent<RectTransform>();
        //Debug.Log("anPosition " + scrollviewRectTransform.anchoredPosition + " locPosition " + scrollviewRectTransform.localPosition);
        //Debug.Log("content   " + scrollview.transform.InverseTransformPoint(scrollview.content.position) 
        //        + " Child(0) " + scrollview.transform.InverseTransformPoint(scrollview.content.GetChild(0).position));
    }
}
