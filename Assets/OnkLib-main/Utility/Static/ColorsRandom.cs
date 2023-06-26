using UnityEngine;

public static class ColorsRandom
{
    public static Color GetRandomColor3()
    {
        Color[] colors = { Color.red, Color.blue, Color.green };

        int randomIndex = Random.Range(0, colors.Length);
        return colors[randomIndex];
    }

    public static Color GetRandomColor5(){
        // public Color teamColor1 = new Color(0.0f, 0.0f, 1.0f);   // ロイヤルブルー
        // public Color teamColor2 = new Color(1.0f, 0.0f, 0.0f);   // レッド
        // public Color teamColor3 = new Color(0.0f, 1.0f, 0.0f);   // ネオングリーン
        // public Color teamColor4 = new Color(1.0f, 0.5f, 0.0f);   // サンセットオレンジ
        // public Color teamColor5 = new Color(0.5f, 0.0f, 0.5f);   // パープル
        Color[] colors = { Color.blue, Color.red, Color.magenta, Color.yellow, Color.cyan };

        int randomIndex = Random.Range(0, colors.Length);
        return colors[randomIndex];
    }
}
