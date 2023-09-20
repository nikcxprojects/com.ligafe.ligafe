using UnityEngine.UI;
using UnityEngine;

public class VibraOption : MonoBehaviour
{
    private Transform handler;

    public static int IsVibraInt
    {
        get => PlayerPrefs.GetInt("IsVibraInt", 1);
        set => PlayerPrefs.SetInt("IsVibraInt", value);
    }

    private void Awake()
    {
        handler = transform.GetChild(0);
        GetComponent<Button>().onClick.AddListener(() =>
        {
            var isMusicEnable = IsVibraInt > 0;
            isMusicEnable = !isMusicEnable;
            IsVibraInt = isMusicEnable ? 1 : 0;

            var x = isMusicEnable ? 52 : -52;
            handler.localPosition = new Vector2(x, 0);
        });

        var x = IsVibraInt > 0 ? 52 : -52;
        handler.localPosition = new Vector2(x, 0);
    }
}
