using UnityEngine;

// CreateAssetMenu属性を使用することで`Assets > Create > ScriptableObjects > CreasteEnemyParamAsset`という項目が表示される
// それを押すとこの`EnemyParamAsset`が`Data`という名前でアセット化されてassetsフォルダに入る
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/firework")]
public class FireworksSet : ScriptableObject
{
    // データ群の先頭をstringにして名前等に設定するとInspectorで見たときに項目TOPに表示されるので見やすくなります。
    public string EnemyName = "花火";

    // privateでも[SerializeField]をつけることでInspectorで確認できるようになります。
    [SerializeField]
    public  FireworkType type;
    [SerializeField]
    public  FireWork prefab;
    // [SerializeField]
    // public int Level;

}