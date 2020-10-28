using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class HPPlayer : HPBehaviour
{
    public UnityAction<bool> OnChangeDied;
    [SerializeField] private int health;

    [Header("Components")]
    [SerializeField] private Material currentMaterial;
    [SerializeField] private Material damageMaterial;
    [SerializeField] private GameObject Thangs;

    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;


    


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
        transform.position = new Vector3(transform.position.x, 1.55f, transform.position.z);
        EnabledItemToObject(); // включаем объекты игрока
        OnChangeDied.Invoke(true);
        health = 100;
    }


    private void EnabledItemToObject() // метод включающий объекты игрока
    {
        meshRenderer.enabled = true;
        Thangs.SetActive(true);
        boxCollider.enabled = true;
    }


    private void DisabledItemToObject() // метод отключающий объекты игрока
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
        DisabledItemToObject(); // отключаем объекты игрока
        yield return new WaitForSeconds(3f);
        Rejoice(); // Вызываем метод возрождения
    }
}