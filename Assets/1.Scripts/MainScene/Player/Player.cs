using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field:SerializeField] public float MoveSpeed { get; private set; }
    [field:SerializeField] public float RotationDamping { get; private set; }
    [field:SerializeField] public CharacterController CharacterController {get; private set;}
    
    [field:SerializeField] public Animator Animator {get; private set;}
    private PlayerFSM _playerFSM;
    public PlayerStatHandler statHandler;
    public PlayerInventory playerInventory;
    
    [field:SerializeField] public LayerMask enemyMask {get; private set;}
    public Enemy target;
    
    MainTab sideMainTabUI;
    public bool IsDead {get; private set;}
    private void Awake()
    {
        _playerFSM = new PlayerFSM(this);
        
        CheckComponents();
    }

    private void Start()
    {
        Init();
    }

    private void CheckComponents()
    {
        if(!CharacterController)
            CharacterController = GetComponent<CharacterController>();
        
        if(!Animator)
            Animator = GetComponentInChildren<Animator>();

        statHandler = GetComponent<PlayerStatHandler>();
        if (!statHandler)
        {
            statHandler = gameObject.AddComponent<PlayerStatHandler>();
        }
        
        playerInventory = GetComponent<PlayerInventory>();
        if (!playerInventory)
        {
            playerInventory = gameObject.AddComponent<PlayerInventory>();
        }
    }

    public void Init()
    {
        statHandler.Init();
        
        IsDead = false;
        target = null;

        sideMainTabUI = MainSceneUIManager.Instance.sidePanel.mainTab;
        sideMainTabUI.UpdateGoldText(playerInventory.Gold);
        sideMainTabUI.UpdateLevelText(statHandler.CurrentLevel);
        sideMainTabUI.UpdateExp(statHandler.CurrentEXP, statHandler.MaxEXP);
        sideMainTabUI.UpdateStatText(statHandler.ATK, statHandler.DEF);
        
        
        _playerFSM.ChangeState(_playerFSM.playerMoveState);
    }

    private void Update()
    {
        _playerFSM.UpdateMachine();
    }

    public void TakeDamage(float damage)
    {
        float actualDamage = Mathf.Max(1, damage - statHandler.DEF);
        statHandler.ChangeHP(-actualDamage);

        if (statHandler.CurrentHP <= 0)
        {
            Die();
        }
    }

    public void GainGold(int amount)
    {
        playerInventory.AddGold(amount);
        sideMainTabUI.UpdateGoldText(playerInventory.Gold);
    }

    public void GainExp(int amount)
    {
        statHandler.GainEXP(amount);
        sideMainTabUI.UpdateExp(statHandler.CurrentEXP, statHandler.MaxEXP);
        sideMainTabUI.UpdateLevelText(statHandler.CurrentLevel);
    }

    private void Die()
    {
        IsDead = true;
        Animator.SetTrigger(AnimationStringData.IsDie);
        enabled = false;
        _playerFSM.StopMachine();
        BattleManager.Instance.Restart();
    }

    public void ObtainItem()
    {
        Item item = ItemDataConnector.Instance.GetRandomItem();
        playerInventory.AddItem(item);
    }
}
