﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
   
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // screen の長さを定義（touch用）
    private float screenwidth = Screen.width;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            //左矢印キーを押した時左フリッパーを動かす
            //if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") 

            if ((touch.position.x < (screenwidth / 2)) && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
            }
            //右矢印キーを押した時右フリッパーを動かす
            //if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") 
            if ((touch.position.x > (screenwidth / 2)) && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
            }

            //矢印キー離された時フリッパーを元に戻す

            //if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") 

            if (touch.phase == TouchPhase.Ended)
            {

                SetAngle(this.defaultAngle);
            }
            //if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
            //{
            //    SetAngle(this.defaultAngle);
            //}
        }
    }

    //フリッパーの傾きを設定

    public void SetAngle(float angle){
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}
