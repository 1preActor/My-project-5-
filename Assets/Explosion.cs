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

    public void CorrectionExplode() => SetExplode();

    private void SetExplode()
    {
        _radiusExplosian *= 2;
        _forceExplosian *= 2;
    }
}