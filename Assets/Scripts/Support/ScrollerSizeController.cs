using UnityEngine;
using UnityEngine.UI;

public class ScrollerSizeController : MonoBehaviour
{
    private RectTransform _mr;
    private float _width, _cardWidth, _spacing;
    private int _girlsCont;

    private void Start()
    {
        _mr = GetComponent<RectTransform>();
        if (GetComponentInChildren<GirlCollection>() != null)
        {
            _cardWidth = GetComponentInChildren<GirlCollection>().gameObject.GetComponent<RectTransform>().rect.width;
            _spacing = GetComponent<HorizontalLayoutGroup>().spacing;
            CalculateWidth();
            _mr.localPosition = new Vector3(_width / 2 - 727.5f, 0, 0);
        }
    }

    public void SetGirlsCount(int count)
    {
        _girlsCont = count;
    }

    private void CalculateWidth()
    {
        _width = (_cardWidth + _spacing) * _girlsCont;
        _mr.sizeDelta = new Vector2(_width, _mr.sizeDelta.y);
    }
}
