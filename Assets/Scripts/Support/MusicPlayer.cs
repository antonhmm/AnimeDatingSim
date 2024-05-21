using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;

    [SerializeField] List<AudioClip> _playList;
    private AudioSource _musicPlayer;
    private int _playTrack = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _musicPlayer = GetComponent<AudioSource>();
    }
    private void Start()
    {
        PlayMusic();
    }

    private void Update()
    {
        if (!_musicPlayer.isPlaying)
        {
            _playTrack++;
            if (_playTrack >= _playList.Count)
            {
                _playTrack = 0;
            }
            PlayMusic();
        }
    }

    private void PlayMusic()
    {
        AudioClip clip = _playList[_playTrack];
        _musicPlayer.PlayOneShot(clip);
    }
}
