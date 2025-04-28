using UnityEngine;
using UnityEngine.Events;

public class SimpleIntData : MonoBehaviour
{
    public int value;
    public UnityEvent onValueChanged; // <- ����� ����

    public void UpdateValue(int amount)
    {
        value += amount;
        onValueChanged?.Invoke(); // <- �������� �������
    }

    public void SetValue(int amount)
    {
        value = amount;
        onValueChanged?.Invoke();
    }
}
