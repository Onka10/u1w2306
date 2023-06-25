using UnityEngine;

public class FrontLauncher : MonoBehaviour
{
    public void LaunchFirework(FireworkData fireworkData, FireWork fireworksPrefab)
    {
        // 打ち上げ座標の設定
        Vector3 launchPosition = transform.position;

        // プレハブをインスタンス化して打ち上げる
        FireWork instantiatedFirework = Instantiate(fireworksPrefab, launchPosition, Quaternion.identity);

        // 打ち上げ処理の実装（Fireworkコンポーネントにパラメータを設定）
        instantiatedFirework.SetParentParticleProperties(fireworkData.fireColor, fireworkData.maxParticles, fireworkData.scale);
        instantiatedFirework.SetAllChildParticleProperties(fireworkData.fireColor, fireworkData.maxParticles);
    }
}
