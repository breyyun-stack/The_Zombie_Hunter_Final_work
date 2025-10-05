using System.Security.Cryptography;
using UnityEngine;

public class StateAttack : State
{
    [SerializeField] private AnimationCurve _curve;

    private GameObject _player;

    [SerializeField] float _radius;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Exit()
    {
        animator.SetBool("isAttack", false);
    }

    public override void Execute()
    {
        animator.SetBool("isAttack", true);

        Debug.Log("Атака");
    }

    public override float Evaluate()
    {
        var distFloat = Vector3.Distance(this.transform.position, _player.transform.position);

        var clamp = Mathf.Clamp(distFloat, 0, _radius);

        var dist = _curve.Evaluate((_radius - clamp) / _radius);

        return dist;
    }
}
