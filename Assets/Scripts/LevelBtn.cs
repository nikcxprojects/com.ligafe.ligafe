using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    public static int OpenedCount
    {
        get => PlayerPrefs.GetInt("openedcount", 1);
        set => PlayerPrefs.SetInt("openedcount", value);
    }

    public static int currentLevel;

    private Image Image { get; set; }
    private Text LevelCountText { get; set; }

    [SerializeField] Sprite unlockSprite;
    [SerializeField] Sprite lockSprite;

    private void Awake()
    {
        LevelCountText = GetComponentInChildren<Text>();
        LevelCountText.text = $"{transform.GetSiblingIndex() + 1}";

        Image = GetComponent<Image>();
        Image.sprite = transform.GetSiblingIndex() + 1 <= OpenedCount ? unlockSprite : lockSprite;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if(transform.GetSiblingIndex() + 1 > OpenedCount)
            {
                return;
            }

            currentLevel = transform.GetSiblingIndex() + 1;
            Instantiate(Resources.Load<GameObject>("hide"));
            Invoke(nameof(LoadScene), 1.0f);
        });
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("game");
    }
}
