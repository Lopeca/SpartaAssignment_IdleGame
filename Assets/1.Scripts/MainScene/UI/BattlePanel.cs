
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattlePanel : MonoBehaviour
{
    // HP
    [SerializeField] private Image hpBar;
    [SerializeField] private TextMeshProUGUI hpText;
    
    // 페이드
    [SerializeField] Image battleFadeSquare;
    const float fadeDuration = 0.5f;
    public bool fadeComplete;
    
    // 웨이브 표시기
    public WaveIndicator waveIndicator;
    
    private void Awake()
    {
        battleFadeSquare.color = new Color(0, 0, 0, 0);
    }

    public void UpdateHP(float currentHP, float maxHP)
    {
        float percentage = currentHP/maxHP;
        hpBar.DOKill();
        hpBar.DOFillAmount(percentage, 1f).SetEase(Ease.OutCubic);
        
        hpText.text = $"{currentHP} / {maxHP}";
    }

    public void BattleFadeIn()
    {
        fadeComplete = false;
        battleFadeSquare.DOFade(0f, fadeDuration).OnComplete(() => fadeComplete = true);
    }
    public void BattleFadeOut()
    {
        fadeComplete = false;
        battleFadeSquare.DOFade(1f, fadeDuration).OnComplete(() => fadeComplete = true);
    }

    private void OnDestroy()
    {
        battleFadeSquare.DOKill();
        hpBar.DOKill();
    }
}
