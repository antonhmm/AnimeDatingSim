using System.Collections;
using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;
    [SerializeField] private Animator _animGoldIcon, _animGoldText;
    private void Start()
    {
        Player.instance.onGoldChanged += OnPlayerGoldChanged;
        _goldText.text = SaveLoadManager.instance.Gold.ToString();
    }
    
    public void NoGoldAnimation()
    {
        StartCoroutine(NoGoldAnim());   
    }

    public void OnPlayerGoldChanged(int gold)
    {
        _goldText.text = gold.ToString();
    }

    private void OnEnable()
    {
        if (Player.instance != null)
        {
            Player.instance.onGoldChanged += OnPlayerGoldChanged;
        }
    }
    private void OnDisable()
    {
        Player.instance.onGoldChanged -= OnPlayerGoldChanged;
    }

    private IEnumerator NoGoldAnim()
    {
        _animGoldIcon.SetBool("Anim", true);
        _animGoldText.SetBool("Anim", true);

        yield return new WaitForSeconds(0.5f);

        _animGoldIcon.SetBool("Anim", false);
        _animGoldText.SetBool("Anim", false);
    }
}
