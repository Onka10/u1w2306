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
            StartCoroutine(ExecuteDelayedLog());
        }

        private System.Collections.IEnumerator ExecuteDelayedLog()
        {
            yield return new WaitForSeconds(2);

            HandManager.I.Hand.ObserveCountChanged()
            .Subscribe(OnCountChanged)
            .AddTo(this);

            OnCountChanged(HandManager.I.Hand.Count);
        }

        private void OnCountChanged(int count)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (gameObjects[i] == null)
                {
                    InstantDebug.DebugLog();
                    continue; // nullの場合はスキップして次の要素に進む
                }

                if (i < count)
                {
                    gameObjects[i].SetActive(true);
                    // Debug.Log(HandManager.I.Hand[i].color);
                    img[i].color = HandManager.I.Hand[i].color;
                }
                else
                {
                    gameObjects[i].SetActive(false);
                }
            }
        }

}
