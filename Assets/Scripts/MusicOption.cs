using UnityEngine;
using UnityEngine.UI;

public class MusicOption : MonoBehaviour
{
    private Transform handler;

    public static int IsMusicInt
    {
        get => PlayerPrefs.GetInt("IsMusicInt", 1);
        set => PlayerPrefs.SetInt("IsMusicInt", value);
    }

    private void Awake()
    {
        handler = transform.GetChild(0);
        GetComponent<Button>().onClick.AddListener(() =>
        {
            var isMusicEnable = IsMusicInt > 0;
            isMusicEnable = !isMusicEnable;
            IsMusicInt = isMusicEnable ? 1 : 0;

            var x = isMusicEnable ? 52 : -52;
            handler.localPosition = new Vector2(x, 0);
        });

        var x = IsMusicInt > 0 ? 52 : -52;
        handler.localPosition = new Vector2(x, 0);
    }
}
