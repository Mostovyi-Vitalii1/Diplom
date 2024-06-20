using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgres : MonoBehaviour
{
    public Transform player;
    public Animator animator; // ������� ���� ��� ��������

    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;
    [SerializeField] private float roamingTimerMax = 2f;
    [SerializeField] private float chaseDistance = 10f;
    [SerializeField] private float viewDistance = 15f; // ��������� ������
    [SerializeField] private float viewAngle = 45f;   // ��� ������

    private NavMeshAgent agent;
    private DamagMob damagMob;
    private State state;
    private float roamingTime;
    private Vector3 roamPosition;
    private Vector3 startingPosition;

    public enum State
    {
        Idle,
        Roaming,
        Chasing,
        Attacking
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        damagMob = GetComponent<DamagMob>();
        agent.updateRotation = false;
        startingPosition = transform.position;
        state = State.Idle;
    }

    private void Start()
    {
        if (roamingDistanceMin > roamingDistanceMax)
        {
            float temp = roamingDistanceMin;
            roamingDistanceMin = roamingDistanceMax;
            roamingDistanceMax = temp;
        }
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Idle:
                // ������� �� ����� ��������
                state = State.Roaming;
                roamingTime = roamingTimerMax;
                break;
            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime < 0)
                {
                    Roaming();
                    roamingTime = roamingTimerMax;
                }
                // ��������, �� ������ ��� ������
                if (CanSeePlayer())
                {
                    state = State.Chasing;
                }
                UpdateAnimator();
                break;
            case State.Chasing:
                if (player != null && agent.isOnNavMesh)
                {
                    agent.SetDestination(player.position);

                    Vector3 lookAtPlayer = player.position;
                    lookAtPlayer.z = transform.position.z;
                    transform.LookAt(lookAtPlayer);
                    transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

                    // ���� ������� ������ �� ��� ��������� �������������, ���������� �� ����� ��������
                    if (Vector3.Distance(transform.position, player.position) > chaseDistance)
                    {
                        state = State.Roaming;
                    }

                    // ���� ��� ������� �� ������, ���������� �� ����� �����
                    if (Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance)
                    {
                        state = State.Attacking;
                    }
                }
                UpdateAnimator();
                break;
            case State.Attacking:
                if (player != null)
                {
                    Vector3 lookAtPlayer = player.position;
                    lookAtPlayer.z = transform.position.z;
                    transform.LookAt(lookAtPlayer);
                    transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

                    // ���� ������� ������ �� ��� ��������� �����, ���������� �� ����� �������������
                    if (Vector3.Distance(transform.position, player.position) > agent.stoppingDistance)
                    {
                        state = State.Chasing;
                    }

                    // ������ ������� �����
                    if (damagMob.GetDamageTimer() >= damagMob.damageInterval)
                    {
                        animator.SetTrigger("Attack");
                        damagMob.ResetDamageTimer(); // �������� ������� ���� ������� �����
                    }
                }
                UpdateAnimator();
                break;
        }
    }

    private void Roaming()
    {
        roamPosition = GetRoamingPosition();
        agent.SetDestination(roamPosition);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + new Vector3(
            Random.Range(-roamingDistanceMax, roamingDistanceMax),
            0,
            Random.Range(-roamingDistanceMax, roamingDistanceMax)
        );
    }

    private bool CanSeePlayer()
    {
        if (player == null) return false;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < viewDistance)
        {
            float angleBetweenMobAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if (angleBetweenMobAndPlayer < viewAngle / 2)
            {
                if (!Physics.Linecast(transform.position, player.position, out RaycastHit hit))
                {
                    return true;
                }
                else if (hit.transform == player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void UpdateAnimator()
    {
        // ��������� ���������� ��������� ������� �� �����
        if (state == State.Roaming || state == State.Chasing)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (state == State.Attacking)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        // ��������� ��������� �������� ��� �������
        Vector3 direction = (player.position - transform.position).normalized;
        if (direction.x > 0)
        {
            animator.SetFloat("direction", 1); // �����
        }
        else if (direction.x < 0)
        {
            animator.SetFloat("direction", -1); // ˳��
        }
    }

    public void SetState(State newState)
    {
        state = newState;
        UpdateAnimator(); // ��������� �������� ��� ��� �����
    }
}
