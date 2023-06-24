using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

public class ScoreAnimation<T> where T : struct
{
    private TextMeshProUGUI scoreText;

    public ScoreAnimation(TextMeshProUGUI textMeshPro)
    {
        scoreText = textMeshPro;
    }

    /// <summary>
    /// スコアのアニメーションを実行します。使用例を参照しろ
    /// </summary>
    /// <param name="beforeScore">アニメーション開始時のスコア。</param>
    /// <param name="afterScore">アニメーション終了時のスコア。</param>
    /// <param name="animationTime">アニメーションの再生時間（秒）。</param>
    /// <returns>アニメーション終了時のスコア。</returns>

        //使用例
        // .Subscribe(async newScore => {
        //     ScoreAnimation<int> scoreAnimation  = new ScoreAnimation<int>(thisScore);
        //     score = await scoreAnimation.AnimateScore(score, newScore, 0.3f);
        // })

    public async UniTask<T> AnimateScore(T beforeScore, T afterScore, float animationTime)
    {
        float elapsedTime = 0f;

        while (elapsedTime < animationTime)
        {
            float rate = elapsedTime / animationTime;
            T animatedScore = Lerp(beforeScore, afterScore, rate);
            scoreText.text = animatedScore.ToString();

            await UniTask.DelayFrame(1);
            elapsedTime += Time.deltaTime;
        }

        scoreText.text = afterScore.ToString();
        return afterScore;
    }

    private T Lerp(T start, T end, float t)
    {
        if (typeof(T) == typeof(int))
        {
            int startValue = System.Convert.ToInt32(start);
            int endValue = System.Convert.ToInt32(end);
            int lerpedValue = Mathf.RoundToInt(Mathf.Lerp(startValue, endValue, t));
            return (T)(object)lerpedValue;
        }
        else if (typeof(T) == typeof(float))
        {
            float startValue = System.Convert.ToSingle(start);
            float endValue = System.Convert.ToSingle(end);
            float lerpedValue = Mathf.Lerp(startValue, endValue, t);
            return (T)(object)lerpedValue;
        }
        else
        {
            Debug.LogError("Unsupported type for score animation!");
            return default;
        }
    }
}
