using System;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider ManaSlider;
    [SerializeField] private PlayerManager _playerManager;

    private void Awake()
    {
        _playerManager.OnManaChanged += ChangeMana;
    }

    public void ChangeMana(int currentMana, int maxMana)
    {
        ManaSlider.value = (float)currentMana / maxMana;
    }
}
