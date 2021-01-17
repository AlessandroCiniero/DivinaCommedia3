using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

public class Movimento : MonoBehaviour
{
    public enum GuardState
    {
        Chase,
        Attack
    }

    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _minChaseDistance = 1000f;
    [SerializeField] private float _minAttackDistance = 1000f;
    [SerializeField] private float _stoppingDistance = 1000f;

    private GuardState _currentGuardState;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        _currentGuardState = GuardState.Chase;

    }

    void Update()
    {
        UpdateState();
        CheckTransition();
    }
   

    private void UpdateState()
    {
        switch (_currentGuardState)
        {
           
            case GuardState.Chase:
                FollowTarget();
                _animator.SetBool("fermo", false);
                break;
            case GuardState.Attack:
                _animator.SetBool("fermo", true);
                Attack();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void CheckTransition()
    {
        GuardState newGuardState = _currentGuardState;

        switch (_currentGuardState)
        {

            case GuardState.Chase:
                
                if (IsTargetWithinDistance(_minAttackDistance))
                {
                    newGuardState = GuardState.Attack;
                    break;
                }
                break;

            case GuardState.Attack:
                if (!IsTargetWithinDistance(_stoppingDistance))
                    newGuardState = GuardState.Chase;
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        if (newGuardState != _currentGuardState)
        {
            Debug.Log($"Changing State FROM:{_currentGuardState} --> TO:{newGuardState}");
            _currentGuardState = newGuardState;
        }
    }

    private void Attack()
    {
        if (IsTargetWithinDistance(_stoppingDistance))
        {
            _navMeshAgent.isStopped = true;

            Vector3 targetDirection = _target.transform.position - transform.position;
            targetDirection.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 150f * Time.deltaTime);
        }
        else
            FollowTarget();
    }

    private void FollowTarget()
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.SetDestination(_target.transform.position);
    }

    private bool IsTargetWithinDistance(float distance)
    {
        return (_target.transform.position - transform.position).sqrMagnitude <= distance * distance;
    }


}