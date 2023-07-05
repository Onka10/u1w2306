using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class BackLauncher : MonoBehaviour
{
    public float minDelay = 1f;  // ランダムな待機時間の最小値
    public float maxDelay = 5f;  // ランダムな待機時間の最大値
    LaunchManager launchManager;
    public int id=0;

    private void Start() {
        launchManager = LaunchManager.I;
    }

    public async UniTask StartBackFireScheduler()
    {
        while (true)
        {
            // fireworkDataBaseが空でない場合にBackFireを呼び出す
            if (launchManager.fireworkDataBase.Count > 0){
                // ランダムな秒数を待機
                // float delay = UnityEngine.Random.Range(minDelay, maxDelay);
                //茶々式
                float delay =  10 / launchManager.fireworkDataBase.Count + 1;
                await UniTask.Delay((int)(delay * 1000));

                //打ち上げ処理
                // Debug.Log("うちあげ"+id);
                int index = UnityEngine.Random.Range(0,launchManager.fireworkDataBase.Count);
                LaunchFirework(launchManager.fireworkDataBase[index],FWSetManager.I.GetFireworkPrefabs(launchManager.fireworkDataBase[index].FWtype));
                SEManager.I.Fire();
                ScoreManager.I.AddTotalScoreFromBack();
            }
        }
    }

    void LaunchFirework(FireworkData fireworkData, FireWork fireworksPrefab)
    {
    // 打ち上げ座標の設定
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(0f, 4f);// ランダムなy座標を範囲内で調整
        float z = transform.position.z; // クラスがアタッチされているオブジェクトのz座標を使用
        Vector3 launchPosition = new Vector3(x, y, z);

        // プレハブをインスタンス化して打ち上げる
        FireWork instantiatedFirework = Instantiate(fireworksPrefab, launchPosition, Quaternion.identity);

        // 打ち上げ処理の実装（Fireworkコンポーネントにパラメータを設定）
        instantiatedFirework.SetParentParticle(fireworkData.fireColor, fireworkData.maxParticles, fireworkData.scale);
        instantiatedFirework.SetAllChildParticle(fireworkData.fireColor, fireworkData.maxParticles);
        instantiatedFirework.InBack = true;
    }
}