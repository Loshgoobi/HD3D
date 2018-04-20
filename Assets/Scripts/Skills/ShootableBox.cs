using UnityEngine;

public class ShootableBox : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int _initialHealth = 2;
    [SerializeField]
    private ParticleSystem _explosionParticle;

    private int _currentMana;

    private void OnEnable()
    {
        _currentMana = _initialHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentMana--;
        if (_currentMana <= 0)
        {
            SpawnExplosionParticle();
            GameObject.Destroy(this.gameObject);
        }
    }

    private void SpawnExplosionParticle()
    {
        var particle = Instantiate(_explosionParticle, transform.position, Quaternion.identity);
        GameObject.Destroy(particle, 2f);
    }
}