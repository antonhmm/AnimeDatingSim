using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _roundTime = 60f;
    [SerializeField] private Image _timeSlider;
    [SerializeField] private GameObject _endGameCanvas, _particle;
    private float _currentTime;
    private bool _stopTimer = false;

    private void Start()
    {
        _currentTime = _roundTime;
        _timeSlider.fillAmount = 1f;
        StartTimer();
    }

    public void StartTimer()
    {
        _currentTime = _roundTime;
        StartCoroutine(StartTimerTicker());
    }
    
    IEnumerator StartTimerTicker()
    {
        while (_stopTimer == false)
        {
            _currentTime -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (_currentTime <= 0)
            {
                _stopTimer = true;
                EndGame();
            }

            if (_stopTimer == false)
            {
                _timeSlider.fillAmount = _currentTime / _roundTime;
                float parPos = _timeSlider.fillAmount * 400 - 160;
                _particle.transform.localPosition = new(parPos, 0, -1);
            }
        }
    }

    private void EndGame()
    {
        Time.timeScale = 0f;
        _endGameCanvas.SetActive(true);
    }
}
