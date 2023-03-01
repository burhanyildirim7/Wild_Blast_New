using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSekilDegistir : MonoBehaviour
{
    [SerializeField] private GameObject _default;
    [SerializeField] private GameObject _horizontal;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private GameObject _rainbow;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Start()
    {
        //_default.SetActive(true);
        _spriteRenderer.enabled = true;
        _horizontal.SetActive(false);
        _bomb.SetActive(false);
        _rainbow.SetActive(false);
    }

    public void HorizontalAc()
    {
        //_default.SetActive(false);
        _spriteRenderer.enabled = false;
        _horizontal.SetActive(true);
        _bomb.SetActive(false);
        _rainbow.SetActive(false);
    }

    public void BombAc()
    {
        //_default.SetActive(false);
        _spriteRenderer.enabled = false;
        _horizontal.SetActive(false);
        _bomb.SetActive(true);
        _rainbow.SetActive(false);
    }

    public void RainbowAc()
    {
        //_default.SetActive(false);
        _spriteRenderer.enabled = false;
        _horizontal.SetActive(false);
        _bomb.SetActive(false);
        _rainbow.SetActive(true);
    }

    public void DefaultAc()
    {
        //_default.SetActive(true);
        _spriteRenderer.enabled = true;
        _horizontal.SetActive(false);
        _bomb.SetActive(false);
        _rainbow.SetActive(false);
    }
}
