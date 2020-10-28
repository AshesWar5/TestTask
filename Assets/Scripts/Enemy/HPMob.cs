using System.Collections;

using UnityEngine;
using UnityEngine.Events;

public class HPMob : HPBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private Material currentMaterial, damageMaterial;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    [SerializeField] private GameObject Thangs;
    public UnityAction<bool> OnChangeDied;


    public override bool SetDamege(int damege)
    {
        health -= damege;
        StartCoroutine(DamegeRender());


        if (health > 0)
        {
            return true;
        }
        else
        {
            StartCoroutine(Died());
            return false;
        }
    }


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Rejoice()
    {
        transform.position = new Vector3(Random.Range(1.3f, 10.77f), 1.55f, Random.Range(-25f, -12f));
        OnChangeDied.Invoke(true);
        EnabledItemToObject(); // включаем объекты врага
        health = 100;
    }


    private void EnabledItemToObject() // метод включающий объекты врага
    {
        meshRenderer.enabled = true;
        Thangs.SetActive(true);
        boxCollider.enabled = true;
    }


    private void DisabledItemToObject() // метод отключающий объекты врага
    {
        Thangs.SetActive(false);
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
    }


    private IEnumerator DamegeRender()
    {
        meshRenderer.material = damageMaterial;
        yield return new WaitForSeconds(1f);
        meshRenderer.material = currentMaterial;
    }


    private IEnumerator Died()
    {
        OnChangeDied.Invoke(false);
        DisabledItemToObject(); // отключаем объекты врага
        yield return new WaitForSeconds(10f);
        Rejoice(); // Вызываем метод возрождения
    }
}