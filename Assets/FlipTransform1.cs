using UnityEngine;

public class FlipTransformBehaviour : MonoBehaviour
{
    private Transform characterTransform;
    private float lastPositionX;
    private Vector3 originalScale;

    void Start()
    {
        characterTransform = transform; // ��������� ������ �� Transform
        lastPositionX = characterTransform.position.x;
        originalScale = characterTransform.localScale; // ���������� ����������� Scale
    }

    void Update()
    {
        float currentPositionX = characterTransform.position.x;

        if (currentPositionX > lastPositionX)
        {
            characterTransform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (currentPositionX < lastPositionX)
        {
            characterTransform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }

        lastPositionX = currentPositionX;
    }
}
