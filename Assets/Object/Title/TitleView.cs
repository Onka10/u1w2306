using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class TitleView : MonoBehaviour
{
        void Start()
        {
            this.gameObject.GetComponent<Button>().OnClickAsObservable()
            .Subscribe(_ => PhaseManager.I.Play())
            .AddTo(this);  
        }
}
