using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableItem : Item
{
    public const float Buff = 3f;
    
    private void Start() => InitializeBaseData();
    
    public override void InitializeBaseData()
    {
        ItemType = PoolCode.UnbreakableItem;
    }
    protected override void Effect(GameObject player)
    {
        GameManager.Instance.GetScore(Score);
        player.GetComponent<Player>().SetUnbreakableMode(Buff);
        PoolManager.Instance.DestroyPrefab(gameObject, ItemType);
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Effect(col.gameObject);
        }
        base.OnTriggerEnter2D(col);
    }
}
