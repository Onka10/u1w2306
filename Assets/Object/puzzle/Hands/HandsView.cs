using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class HandsView : MonoBehaviour
{
    //非表示にするからオブジェクト
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Image[] img;

    private void Start()
    {
        gameObjects[0].GetComponent<Button>().OnClickAsObservable()
        .Subscribe(_=>ButtonManager.I.SelectHandPiece(0))
        .AddTo(this);

        gameObjects[1].GetComponent<Button>().OnClickAsObservable()
        .Subscribe(_=>ButtonManager.I.SelectHandPiece(1))
        .AddTo(this);

        gameObjects[2].GetComponent<Button>().OnClickAsObservable()
        .Subscribe(_=>ButtonManager.I.SelectHandPiece(2))
        .AddTo(this);

        StartCoroutine("ExecuteDelayedLog");

    }

    private System.Collections.IEnumerator ExecuteDelayedLog()
    {
        yield return new WaitForSeconds(.05f);

        //ハンドの更新
        HandManager.I.Hand.ObserveCountChanged()
        .Subscribe(OnCountChanged)
        .AddTo(this);

        //選択の色変化
        HandManager.I.Now
        .Subscribe(n =>Selected(n))
        .AddTo(this);

        //初回を強制
        OnCountChanged(HandManager.I.Hand.Count);
        Selected(0);
    }

    private void OnCountChanged(int count)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] == null)
            {
                // InstantDebug.DebugLog();
                continue; // nullの場合はスキップして次の要素に進む
            }

            if (i < count)
            {
                gameObjects[i].SetActive(true);
                img[i].color = HandManager.I.Hand[i].GetColor();
            }
            else
            {
                gameObjects[i].SetActive(false);
            }
        }
    }

    private void Selected(int n){
        if(n < 0) return;
        
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Debug.Log("ee");
            gameObjects[i].GetComponent<Button>().image.color = i == n ? Color.yellow : Color.white;
        }
    }

}
