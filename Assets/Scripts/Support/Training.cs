using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Training : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tSteps;
    [SerializeField] private TextMeshProUGUI _textPageNumber;
    private int _step = 0;

    private void OnEnable()
    {
        _step = 0;
        _tSteps[_step].SetActive(true);
        UpdateText();
    }
    public void NextStep()
    {
        if (_step + 1 >= _tSteps.Count)
        {
            return;
        }
        _tSteps[_step].SetActive(false); 
        _step++;
        UpdateText();
        _tSteps[_step].SetActive(true);
    }

    public void PreviousStep()
    {
        if (_step == 0)
        {
            return;
        }
        _tSteps[_step].SetActive(false);
        _step--;
        UpdateText();
        _tSteps[_step].SetActive(true);
    }

    private void UpdateText()
    {
        int pageNumber = _step + 1;
        _textPageNumber.text = pageNumber + " / " + _tSteps.Count;
    }
}
