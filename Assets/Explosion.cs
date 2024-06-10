using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radiusExplosian;
    [SerializeField] private float _forceExplosian;

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusExplosian);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rigidbody = colliders[i].attachedRigidbody;

            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_forceExplosian, transform.position, _radiusExplosian);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radiusExplosian);
    }
}