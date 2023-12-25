using DG.Tweening;
using UnityEngine;

public class Target : MonoBehaviour
{
    private readonly int maxHP = 1000;
    private int currentHP;

    private Material mainMaterial;

    [SerializeField] private Renderer meshRenderer;

    private EnamySpavner _spavner;

    private void Awake()
    {
        currentHP = maxHP;
        mainMaterial = meshRenderer.material;
    }

    public void Init(EnamySpavner spavner)
    {
        _spavner = spavner;
    }

    private void OnEnable()
    {
        transform.DOMoveX(Random.Range(-10, 10), 2).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
    }


    public void GetDamage(int damage)
    {
        mainMaterial.DOColor(Color.red, 0.05f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutBounce).OnComplete(() =>
        {
            mainMaterial.SetColor("_Color", Color.white);
        });

        transform.DOScale(1.5f, 0.05f).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            transform.localScale = Vector3.one;
        });

        Debug.Log(damage + " was taken");

        currentHP -= damage;

        if (currentHP <= 0)
            Death();
    }

    private void Death()
    {
        gameObject.SetActive(false);
        GameHandler.GameInstance.uiModule.SetScore(20);
        _spavner.Spawn();
    }
}