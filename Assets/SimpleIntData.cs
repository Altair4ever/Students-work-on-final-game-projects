using UnityEngine;
using UnityEngine.Events;

public class SimpleIntData : MonoBehaviour
{
    public int value;
    public UnityEvent onValueChanged; // <- םמגמו ןמכו

    public void UpdateValue(int amount)
    {
        value += amount;
        onValueChanged?.Invoke(); // <- גûחûגאול סמבûעטו
    }

    public void SetValue(int amount)
    {
        value = amount;
        onValueChanged?.Invoke();
    }
}
