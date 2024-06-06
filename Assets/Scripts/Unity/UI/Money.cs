using Domain;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Money : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Reset()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Clicker.ChengedMoney += OnChengedMoney;
    }

    private void OnDisable()
    {
        Clicker.ChengedMoney -= OnChengedMoney;
    }

    private void OnChengedMoney(int money)
    {
        _text.text = money.ToString();
    }
}
