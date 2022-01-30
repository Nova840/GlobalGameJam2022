using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer mainSprite;

    [SerializeField]
    protected Element element;

    [Min(0)]
    [SerializeField]
    protected float moveSpeed = 1;

    [Min(0)]
    [SerializeField]
    protected int hitDamage = 25;

    protected Rigidbody2D _rigidbody;

    public Transform TargetingPlayer { get; private set; }

    public static event Action OnEnemyDefeated;

    protected abstract Vector2 Velocity { get; }

    protected virtual void Awake()
        => _rigidbody = GetComponent<Rigidbody2D>();

    protected virtual void Start()
        => TargetingPlayer = element switch
        {
            Element.FIRE => Player.LeftPlayer,
            Element.ICE => Player.RightPlayer,
            _ => Player.RightPlayer,
        };

    private void Update()
    {
        if (Vector2.Angle(_rigidbody.velocity, Vector2.right) != 90)
        {
            mainSprite.flipX = !(Vector2.Angle(TargetingPlayer.position - transform.position, Vector2.right) > 90);
        }
    }

    protected virtual void FixedUpdate()
        => _rigidbody.velocity = Velocity;

    protected virtual void OnDestroy()
        => OnEnemyDefeated?.Invoke();

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PlayerHitTrigger")
            && collider.attachedRigidbody.TryGetComponent(out Player player)
            && player.transform == TargetingPlayer)
        {
            player.GetComponent<Health>().Damage(hitDamage);
            Destroy(gameObject);
        }
    }
}
