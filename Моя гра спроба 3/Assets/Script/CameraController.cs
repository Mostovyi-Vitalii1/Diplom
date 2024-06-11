using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform; // ��������� ������
    public Transform mapTransform; // ��������� ����� (���������, ������� ��'���, �� ������� ������ �����)
    public Vector2 mapSize; // ������ ����� (������ � ������)

    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        // ���� cameraTransform �� �������, ������������� ��������� ��'����, �� ����� ����������� ��� ������
        if (cameraTransform == null)
        {
            cameraTransform = transform;
        }

        // ���������� �������� ������ � ������ ������
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        // ��������� ������� ������
        float clampedX = Mathf.Clamp(cameraTransform.position.x, mapTransform.position.x - mapSize.x / 2 + halfWidth, mapTransform.position.x + mapSize.x / 2 - halfWidth);
        float clampedY = Mathf.Clamp(cameraTransform.position.y, mapTransform.position.y - mapSize.y / 2 + halfHeight, mapTransform.position.y + mapSize.y / 2 - halfHeight);

        // ��������� ������� ������
        cameraTransform.position = new Vector3(clampedX, clampedY, cameraTransform.position.z);
    }
}
