using UnityEngine;

public class GoalTriggerUI : MonoBehaviour
{
    public GameObject levelCompletePanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something entered the trigger: " + other.name);

        if (other.CompareTag("Player"))
        {
            levelCompletePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}