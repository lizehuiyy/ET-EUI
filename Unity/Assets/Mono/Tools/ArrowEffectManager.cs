using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;


public class ArrowEffectManager : MonoBehaviour
{
    public GameObject reticleBlock;
    public GameObject reticleArrow;
    public int MaxCount = 18;
    public Vector3 startPoint; // ��ʼ��  
    public Vector3 controlPoint1; // ���Ƶ�1  
    public Vector3 controlPoint2; // ���Ƶ�2  
    public Vector3 endPoint; // ������  
    public GameObject mouseObj = null;
    public List<GameObject> ArrowItemList;
    public List<Image> RendererItemList;

    public List<RectTransform> CollisionList;
    public List<GameObject> HighlightList;

    private Animator Arrow_anim;
    public bool isSelect = true;

    public bool IsSelect = true;
    public Camera UICamera = null;
    private void Awake()
    {
        UICamera = GameObject.Find("UICamera").GetComponent<Camera>();


        InitData();
    }
    private void InitData()
    {
        ArrowItemList = new List<GameObject>();
        RendererItemList = new List<Image>();
        CollisionList = new List<RectTransform>();
        HighlightList = new List<GameObject>();
        for (int i = 0; i < MaxCount; i++)
        {
            GameObject Arrow = (i == MaxCount - 1) ? reticleArrow : reticleBlock;
            GameObject temp = Instantiate(Arrow, this.transform);
            if (i == MaxCount - 1)
            {
                Arrow_anim = temp.GetComponent<Animator>();
            }
            ArrowItemList.Add(temp);
            Image re = temp.transform.GetChild(0).GetComponent<Image>();
            if (re != null)
            {
                RendererItemList.Add(re);
            }
        }
    }
    public void Update()
    {
        Move();
        DrawBezierCurve();
    }

    public void SetCollisionObject(RectTransform Collision,GameObject Highlight)
    {
        CollisionList.Add(Collision);
        HighlightList.Add(Highlight);


    }
    public void ClearCollisionObject()
    {
        CollisionList.Clear();
        HighlightList.Clear();
    }

    private void DrawBezierCurve()
    {
        for (int i = 0; i < ArrowItemList.Count; i++)
        {
            float t = i / (float)(ArrowItemList.Count - 1); // ���� t �� 0 �� 1 ֮��  
            Vector3 position = CalculateBezierPoint(t, startPoint, controlPoint1, controlPoint2, endPoint);
            ArrowItemList[i].gameObject.SetActive(i != ArrowItemList.Count - 2);
            ArrowItemList[i].transform.position = position;
            ArrowItemList[i].transform.localScale = Vector3.one * (t / 2f) + Vector3.one * 0.3f;
            if (i > 0)
            {
                float SignedAngle = Vector2.SignedAngle(Vector2.up,
                ArrowItemList[i].transform.position - ArrowItemList[i - 1].transform.position);
                Vector3 euler = new Vector3(0, 0, SignedAngle);
                ArrowItemList[i].transform.rotation = Quaternion.Euler(euler);
            }
        }
    }
    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.yellow;        
        // Gizmos.DrawLine(startPoint, controlPoint1);       
        // Gizmos.DrawSphere(startPoint, 0.1f);        
        // Gizmos.DrawSphere(controlPoint1, 0.1f);        
        // Gizmos.DrawLine(endPoint, controlPoint2);        
        // Gizmos.DrawSphere(endPoint, 0.1f);        
        // Gizmos.DrawSphere(controlPoint2, 0.1f);    
    }
    public void Move()
    {
        
        Vector3 mousePosition = Input.mousePosition; // ��ȡ���λ��  
        //mousePosition.z = Camera.main.nearClipPlane; // ����z����Ϊ��������ü�ƽ���λ��  
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //worldPosition.z = 2f;
        Vector3 worldPosition = UICamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y,100));
        Debug.Log(Camera.main.nearClipPlane + "mousePosition" + mousePosition + "worldPosition" + worldPosition);
        //worldPosition.z = 0;


        //mouseObj.transform.position = worldPosition;// new Vector3(worldPosition.x, worldPosition.y,0);
        Vector2 position = transform.InverseTransformPoint(worldPosition);
        mouseObj.transform.localPosition = position;


        for (int i = 0; i < CollisionList.Count; i++)
        {
            Vector2 pos = CollisionList[i].parent.InverseTransformPoint(worldPosition);
            Debug.Log("i" + i + "pos" + pos + "CollisionList[i].localPosition" +  CollisionList[i].localPosition + "CollisionList[i].sizeDelta" + CollisionList[i].sizeDelta);
            if (IsPointInsideRectangle(pos, CollisionList[i].localPosition, CollisionList[i].sizeDelta))
            {
                HighlightList[i].gameObject.SetActive(true);
            }
            else
            {
                HighlightList[i].gameObject.SetActive(false);
            }
        }


        endPoint = mouseObj.transform.position;
        controlPoint1 = (Vector2)startPoint + (mouseObj.transform.position - startPoint) * new Vector2(-0.28f, 0.8f);
        controlPoint2 = (Vector2)startPoint + (mouseObj.transform.position - startPoint) * new Vector2(0.12f, 1.4f);
        controlPoint1.z = startPoint.z;
        controlPoint2.z = startPoint.z;
    }

    bool IsPointInsideRectangle(Vector2 point, Vector2 rectanglePosition, Vector2 rectangleSize)
    {
        // ������εı߽�����
        float left = rectanglePosition.x - rectangleSize.x * 0.5f;
        float right = rectanglePosition.x + rectangleSize.x * 0.5f;
        float bottom = rectanglePosition.y - rectangleSize.y * 0.5f;
        float top = rectanglePosition.y + rectangleSize.y * 0.5f;

        // �жϵ��Ƿ��ھ��α߽���
        return point.x >= left && point.x <= right && point.y >= bottom && point.y <= top;
    }


    /// <summary>  
    /// ������ʼλ��  
    /// </summary>  
    /// 
    public void SetStartPos(Vector3 pos)
    {
        startPoint = pos;
        transform.position = startPoint;
    }
    /// <summary>  
    /// ������ɫ  
    /// </summary>  
    public void SetColor(Color color)
    {
        if (RendererItemList == null)
        {
            return;
        }
        for (int i = 0; i < RendererItemList.Count; i++)
        {
            RendererItemList[i].color = color;
        }
    }
    /// <summary>  
    /// ������ɫ  
    /// </summary>  
    /// <param name="isSelect"></param>    
    public void SetColor(bool isSelect)
    {
        IsSelect = isSelect;
        if (isSelect)
        {
            SetColor(Color.red);
        }
        else
        {
            SetColor(Color.white);
        }
    }
    private void PlayAnim()
    {
        if (Arrow_anim == null)
        {
            return;
        }
        Arrow_anim.SetTrigger("select");
    }
    /// <summary>  
    /// ��ȡ�����������м��  
    /// </summary>  
    /// <param name="t">���� t �� 0 �� 1 ֮��</param>  
    /// <param name="startPoint">��ʼ��</param>  
    /// <param name="controlPoint1">�����Ƶ�</param>  
    /// <param name="controlPoint2">�յ���Ƶ�</param>  
    /// <param name="endPoint">�յ�</param>  
    /// <returns></returns>    
    public static Vector3 CalculateBezierPoint(float t, Vector3 startPoint, Vector3 controlPoint1, Vector3 controlPoint2, Vector3 endPoint)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point = uuu * startPoint; // (1-t)^3 * P0  
        point += 3 * uu * t * controlPoint1; // 3 * (1-t)^2 * t * P1  
        point += 3 * u * tt * controlPoint2; // 3 * (1-t) * t^2 * P2  
        point += ttt * endPoint; // t^3 * P3  

        return point;
    }
}
