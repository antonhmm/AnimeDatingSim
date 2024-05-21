using TMPro;
using UnityEngine;

public class ComboCalculator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _comboText;
    [SerializeField] private float _comboNumber = 1f, _comboMulti = 0.2f, _comboLimit = 3f;

    private void Start()
    {
        _comboText.text = "x" + _comboNumber.ToString();
    }

    public float CalculateComboScore(float score)
    {
        score *= _comboNumber;
        return score;
    }

    public void CalculateCombo(bool combo)
    {
        if (combo)
        {
            if (_comboNumber >= _comboLimit)
            {
                return;
            }
            else
            {
                _comboNumber += _comboMulti;
                _comboText.text = "x" + _comboNumber.ToString();
            }
        }
        else if (combo == false)
        {
            _comboNumber = 1f;
            _comboText.text = "x" + _comboNumber.ToString();
        }
    }
}
