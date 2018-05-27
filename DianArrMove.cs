using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class DianArrMove : MonoBehaviour {

    public GameObject moveCube;
    private List<Vector3> pArr;
    private Camera _camera;
    private Vector3 screenV;

    private int len;
    private float s;                //当前要移动的距离
    private float dis;              //cube从一个点开始向另一个点移动的累加距离值
    private float speed = 3;
    private float speedX;
    private float speedY;
    private int moveFlag;

    // Use this for initialization
    void Start()
    {
        pArr = new List<Vector3>();
        _camera = Camera.main;
        screenV = _camera.WorldToScreenPoint(moveCube.transform.position);     //屏幕坐标

    }
    void MoveCount()
    {
        Vector3 p = pArr[0];
        Vector3 v = moveCube.transform.position;
        float dx = p.x - v.x;
        float dy = p.y - v.y;
        s = Mathf.Sqrt(dx * dx + dy * dy);      //获得两点间的距离
        float hudu = Mathf.Atan2(dy, dx);
        speedX = speed * Mathf.Cos(hudu);
        speedY = speed * Mathf.Sin(hudu);
        dis = 0;
        pArr.RemoveAt(0);

        moveFlag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 dianV = Input.mousePosition;    //鼠标坐标
            dianV.z = screenV.z;       //关键步骤，将cube的屏幕坐标的z轴赋给我们鼠标点击的位置的z轴
            Vector3 wv = _camera.ScreenToWorldPoint(dianV);
            pArr.Add(wv);
            if (moveFlag == 0)
                MoveCount();

        }
        if (moveFlag == 1)
        {
            //cube移动
            moveCube.transform.Translate(Vector3.right * Time.deltaTime * speedX);
            moveCube.transform.Translate(Vector3.up * Time.deltaTime * speedY);
            dis += Time.deltaTime * speed;
            if (dis >= s)
            {
                if (pArr.Count>0)
                    MoveCount();
                else
                    moveFlag = 0;

            }
        }
    }
}
