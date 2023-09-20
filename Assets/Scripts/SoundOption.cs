using UnityEngine.UI;
using UnityEngine;

public class SoundOption : MonoBehaviour
{
    private Transform handler;

    public static int IsSfxInt
    {
        get => PlayerPrefs.GetInt("IsSfxInt", 1);
        set => PlayerPrefs.SetInt("IsSfxInt", value);
    }

    private void Awake()
    {
        handler = transform.GetChild(0);
        GetComponent<Button>().onClick.AddListener(() =>
        {
            var isMusicEnable = IsSfxInt > 0;
            isMusicEnable = !isMusicEnable;
            IsSfxInt = isMusicEnable ? 1 : 0;

            var x = isMusicEnable ? 52 : -52;
            handler.localPosition = new Vector2(x, 0);
        });

        var x = IsSfxInt > 0 ? 52 : -52;
        handler.localPosition = new Vector2(x, 0);
    }
}
