using UnityEngine;
using UnityEngine.AI;

public class EnemyAgres : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found!");
        }

        // �������� ��������� ������
        agent.updateRotation = false;
    }

    void Update()
    {
        if (player != null && agent.isOnNavMesh)
        {
            agent.SetDestination(player.position);
            // ��������� ���� � ������ 2D
            Vector3 lookAtPlayer = player.position;
            lookAtPlayer.z = transform.position.z; // Գ����� ��������� �� �� Z
            transform.LookAt(lookAtPlayer);
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z); // Գ����� ��������� �� ���� X � Y
        }
    }
}
