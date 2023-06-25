using UnityEngine;
using System.Collections.Generic;

public class BackLauncher : MonoBehaviour
{
    public void LaunchFirework(FireworkData fireworkData, FireWork fireworksPrefab)
    {
        // 打ち上げ座標の設定
        float x = Random.Range(-8f, 8f);
        float y = transform.position.y; // クラスがアタッチされているオブジェクトのy座標を使用
        float z = transform.position.z; // クラスがアタッチされているオブジェクトのz座標を使用
        Vector3 launchPosition = new Vector3(x, y, z);

        // プレハブをインスタンス化して打ち上げる
        FireWork instantiatedFirework = Instantiate(fireworksPrefab, launchPosition, Quaternion.identity);

        // 打ち上げ処理の実装（Fireworkコンポーネントにパラメータを設定）
        instantiatedFirework.SetParentParticleProperties(fireworkData.fireColor, fireworkData.maxParticles, fireworkData.scale);
        instantiatedFirework.SetAllChildParticleProperties(fireworkData.fireColor, fireworkData.maxParticles);
    }
}