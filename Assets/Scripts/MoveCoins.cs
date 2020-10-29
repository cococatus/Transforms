using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCoins : MonoBehaviour
{
    public RectTransform endPoint;
    public RectTransform startPoint;
    public GameObject coinPrefab;
    public RectTransform parent;
    public Camera uiCam;

    private void OnEnable()
    {
        for (int i = 0; i < 10; i++)
        {
            var coin = Instantiate(coinPrefab, transform).GetComponent<RectTransform>();
            coin.position = startPoint.position;

            Vector3 newPos;
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, endPoint.TransformPoint(endPoint.localPosition), uiCam, out newPos);
            newPos = parent.InverseTransformPoint(endPoint.position);
            //coin.anchoredPosition = newPos;
            //coin.DOAnchorPos(newPos, Random.Range(0.2f, 1f)).SetEase(Ease.InOutQuad);
            
            var startPos = parent.InverseTransformPoint(startPoint.position);
            var waypoints = new Vector3[] { startPos, new Vector3(Random.Range(-50f, 50f), Random.Range(newPos.y / 4f, newPos.y / 2f)), newPos };

            coin.DOLocalPath(waypoints, Random.Range(0.2f, 2f), PathType.CatmullRom, PathMode.TopDown2D);

        }
    }
}
