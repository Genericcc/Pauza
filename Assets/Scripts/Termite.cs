using System;
using System.Collections.Generic;

using MEC;

using UnityEngine;
using UnityEngine.SceneManagement;

using Random = UnityEngine.Random;

public class Termite : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float moveTime = 2f;

    [SerializeField]
    private float timeBetweenMoves = 2f;

    [SerializeField]
    private AnimationCurve animationCurve;
    
    [SerializeField]
    private float killDistance;
    
    private Player _player;
    private Rigidbody _rigidBody;

    private float _moveTimer = 0f;
    private Vector3 _lastPlayerPosition;
    
    private CoroutineHandle _currentCoroutine;
    private bool _isStunned;

    private void Start()
    {
        _player = Player.Instance;
        _rigidBody = GetComponent<Rigidbody>();
        
        _lastPlayerPosition = _player.transform.position;
        _moveTimer = 0f;
        
        gameObject.layer = LayerMask.NameToLayer("Termite");
    }

    private void Update()
    {
        if (_isStunned)
        {
            return;
        }
        
        if (Vector3.Distance(_player.transform.position, transform.position) < killDistance)
        {
            if (_currentCoroutine.IsValid)
            {
                Timing.KillCoroutines(_currentCoroutine);
            }
            
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        if (_isStunned)
        {
            return;
        }
        
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
        
        if (_player == null)
        {
            return;
        }
        
        _moveTimer -= Time.deltaTime;

        if (!_currentCoroutine.IsValid)
        {
            _moveTimer = moveTime;
            _lastPlayerPosition = _player.transform.position;
            _currentCoroutine = Timing.RunCoroutine(_MoveTowardsPlayer(_lastPlayerPosition).CancelWith(gameObject));
        }
    }

    private IEnumerator<float> _MoveTowardsPlayer(Vector3 lastPlayerPosition)
    {
        while (_moveTimer > 0f)
        {
            var playerDir = Vector3.Normalize(lastPlayerPosition - transform.position);
            var random = Random.Range(0f, 1f);
            var offset = animationCurve.Evaluate(random);
            playerDir = new Vector3(playerDir.x + offset, playerDir.y, playerDir.z + offset);

            var newPosition = transform.position + playerDir * (moveSpeed * Time.fixedDeltaTime);
            _rigidBody.MovePosition(newPosition);

            yield return Timing.WaitForOneFrame;
        }

        yield return Timing.WaitForSeconds(timeBetweenMoves);

        _currentCoroutine = new CoroutineHandle();
    }

    public void Stun(float stunDuration)
    {
        _isStunned = true;
        
        if (_currentCoroutine.IsValid)
        {
            Timing.KillCoroutines(_currentCoroutine);
        }
        
        _currentCoroutine = Timing.RunCoroutine(_WaitForStunEnd(stunDuration));
    }

    private IEnumerator<float> _WaitForStunEnd(float stunDuration)
    {
        yield return Timing.WaitForSeconds(stunDuration);
        
        _isStunned = false;
        _currentCoroutine = new CoroutineHandle();
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}