using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Explosion _explosion;

    private int _decreaseNumber = 2;
    private int _minValue = 2;
    private int _maxValue = 6;
    private int _randomMaxValue = 100;
    private float _separationChance = 100;

    private void OnMouseDown()
    {
        Destroy(gameObject);
        CreateCube();
    }

    private void CreateCube()
    {
        int quantity = Random.Range(_minValue, _maxValue);
        float random = Random.Range(0, _randomMaxValue);

        if (_separationChance >= random)
        {
            _separationChance /= _decreaseNumber;

            for (int i = 0; i < quantity; i++)
            {
                Cube cube = Instantiate(this, transform.position, transform.rotation);

                cube.Init();

                _explosion.Explode();
            }

        }
        else
        {
            _explosion.Explode();
        }
    }

    public void Init()
    {
        Vector3 scale = transform.localScale / _decreaseNumber;
        transform.localScale = scale;
        _meshRenderer.material.color = Random.ColorHSV();
    }
}