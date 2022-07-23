using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeBounce : MonoBehaviour
{
    protected Rigidbody2D rigid;

    [SerializeField] Edge edgeViewportPoint;

    /// <summary>
    /// ������Ʈ�� ������ ��ġ ���κп� �΋H���� ��, �ݴ������ ���͸� �������ϴ�.
    /// </summary>
    protected Action<Vector2> onEdgeCollide = (dir) => { };

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < edgeViewportPoint.minX)
        {
            pos.x = edgeViewportPoint.minX;
            onEdgeCollide?.Invoke(Vector2.right);
        }
        if (pos.x > edgeViewportPoint.maxX)
        {
            pos.x = edgeViewportPoint.maxX;
            onEdgeCollide?.Invoke(Vector2.left);
        }
        if (pos.y < edgeViewportPoint.minY)
        {
            pos.y = edgeViewportPoint.minY;
            onEdgeCollide?.Invoke(Vector2.up);
        }
        if (pos.y > edgeViewportPoint.maxY)
        {
            pos.y = edgeViewportPoint.maxY;
            onEdgeCollide?.Invoke(Vector2.down);
        }

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}

[System.Serializable]
public struct Edge
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
}

