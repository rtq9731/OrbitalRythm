using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBaseGenerator : MonoBehaviour
{
    [SerializeField] float mapRadius = 0f;

    LineRenderer lineRender = null;

    private void Awake()
    {
        lineRender = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        GenerateMapBase();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(UpdateMapToFlat());
        }
    }

    public void GenerateMapBase()
    {
        for (int i = 0; i <= 360; i++)
        {
            float cornerAngle = i * Mathf.Deg2Rad;
            lineRender.SetPosition(i, new Vector3(Mathf.Sin(cornerAngle) * mapRadius, Mathf.Cos(cornerAngle) * mapRadius));
        }
    }

    private IEnumerator UpdateMapToFlat()
    {
        for (int i = 0; i <= 360; i++)
        {
            lineRender.SetPosition(i, new Vector3(i, lineRender.GetPosition(0).y, 0));
            yield return new WaitForSeconds(0.01f);
        }
    }

}
