using UnityEngine;

public class MusicDontDestroy : MonoBehaviour
{
    private static MusicDontDestroy Instance { get; set; }
    private AudioSource source;

    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
            source = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        source.mute = MusicOption.IsMusicInt < 1;
    }
}
