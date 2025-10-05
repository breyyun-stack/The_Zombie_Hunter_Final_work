using System.Security.Cryptography;
using UnityEngine;

public class StateChase : State
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
        animator.SetBool("isRun", false);
    }

    public override void Execute()
    {
        Debug.Log("Преследование");

        animator.SetBool("isRun", true);
                
        Vector3 newPosition = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);

        transform.LookAt(newPosition);
    }

    public override float Evaluate()
    {
        var distFloat = Vector3.Distance(this.transform.position, _player.transform.position);

        var clamp = Mathf.Clamp(distFloat, 0, _radius);

        var dist = _curve.Evaluate((_radius - clamp) / _radius);

        return dist;       
    }
}
