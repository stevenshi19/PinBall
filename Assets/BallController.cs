using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;
    private int sumscore=0;
    private int degree = 0;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    private GameObject FinalScoreText;
  
    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得 
        this.gameoverText = GameObject.Find("GameOverText");
        this.FinalScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合

        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            this.FinalScoreText.GetComponent<Text>().text = "TotalScore :" + sumscore;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        //ボールのスコア判定

        if (other.gameObject.tag == "SmallStarTag")
        {
            this.sumscore += 1;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.sumscore += 5;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.sumscore += 2;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.sumscore += 10;
        }

       
    }

}
