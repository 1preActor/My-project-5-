using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Explosion _explosion;

    private int _decreaseNumber = 2;
    private int _minInstantiateChance = 2;
    private int _maxInstantiateChance = 6;
    private int _randomMaxValue = 100;
    private int _chanceToDivide = 50;
    private float _scaleMultiplier = 0.5f;
    private int _randomChanceToDivide;
    private int _randomChanceToInstantiate;

    private void OnMouseDown()
    {
        Destroy(gameObject);
        SpawnCubes();
    }

    private void SpawnCubes()
    {
        _randomChanceToDivide = Random.Range(0, _randomMaxValue);
        
        if (_randomChanceToDivide <= _chanceToDivide)
        {
            _randomChanceToInstantiate = Random.Range(_minInstantiateChance, _maxInstantiateChance);
            transform.localScale *= _scaleMultiplier;
            _chanceToDivide /= _decreaseNumber;
            _explosion.CorrectionExplode();

            for (int i = 0; i < _randomChanceToInstantiate; i++)
            {
                Instantiate(this, transform.position, Quaternion.identity);
                SetObject();
            }
        }
        else
        {
            _explosion.Explode();
        }
    }

    private void SetObject() => _meshRenderer.material.color = Random.ColorHSV();    
}