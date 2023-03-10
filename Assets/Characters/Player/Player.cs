using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity.Characters;
using Yarn.Unity;

public abstract class Player : MonoBehaviour
{
    [SerializeField]
    protected SaveLoadSystem SaveLoadSystem;
    protected string Name;
    protected NodeVisitedTracker NodeTracker;
    protected NPC Self;
    protected LevelInfo Info;
    public NPC TargetNPC = null;
    public Teleport TargetTeleport = null;
    public SaveLoadTrigger SaveLoad;
    public DialogueRunner Runner;
    public bool IsActive = false;
    public CharacterChanger CharacterChanger;
    public PlayerCamera PlayerCamera;
    public CustomInput PlayerInput;
    [SerializeField]
    public float Speed;
    [SerializeField]
    public int Health = 100;
    [SerializeField]
    protected float JumpForce;
    protected Rigidbody2D Rigid;
    protected Animator Animator;
    protected SpriteRenderer Renderer;
    public bool OnGround;
    public LayerMask GroundLayer;
    public bool IsWalking;
    protected float Timer = 0;
    protected bool IsJumping = false;
    protected int IdleState = 0;
    public int Height = 0;
    public float InteractionRadius; 
    public bool GroundCheck()
    {
        if (this is Zima)
            OnGround = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.4F, transform.position.y - 0.5F), new Vector2(transform.position.x + 0.4F, transform.position.y - 0.6F), GroundLayer);
        if(this is Red)
            OnGround = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.4F, transform.position.y - 0.5F), new Vector2(transform.position.x + 0.4F, transform.position.y - 0.9F), GroundLayer);
        return OnGround;
    }
    protected virtual void Awake()
    {
        this.enabled = true;
        Rigid = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Renderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public virtual void Walk()
    {

    }
    public virtual void Jump()
    {

    }
    public virtual void SpecialAbility()
    {

    }
    public virtual void CheckCharacter()
    {

    }
    public int CountPlayers()
    {
        Info = FindObjectOfType<LevelInfo>();
        int Count = 0;
        foreach (Player Obj in FindObjectsOfType<Player>())
            if (Obj.gameObject.activeInHierarchy && Info.CheckCharacter(Obj.Name))
                Count++;
        return Count;
    }
    public void CheckNPC()
    {
            var allParticipants = new List<NPC>(FindObjectsOfType<NPC>());
            TargetNPC = allParticipants.Find(delegate (NPC p)
            {
                return !string.IsNullOrEmpty(p.talkToNode) &&
                (p.transform.position - this.transform.position)
                .magnitude <= InteractionRadius;
            });
            if (TargetNPC != null)
            {
                NodeTracker = FindObjectOfType<NodeVisitedTracker>();
                NodeTracker.dialogueRunner = Runner;
                Runner.StartDialogue(TargetNPC.talkToNode);
            }
    }
    public void CheckTeleport()
    {
        var allParticipants = new List<Teleport>(FindObjectsOfType<Teleport>());
        TargetTeleport = allParticipants.Find(delegate (Teleport T) {
            return (T.transform.position - this.transform.position)
            .magnitude <= InteractionRadius;
        });
        if (TargetTeleport != null && TargetTeleport.IsCharacterHere)
        {
           TargetTeleport.TeleportPlayer(this, PlayerCamera);
        }
    }
    public void CheckSavepoint()
    {
        var allParticipants = new List<SaveLoadTrigger>(FindObjectsOfType<SaveLoadTrigger>());
        SaveLoad = allParticipants.Find(delegate (SaveLoadTrigger S) {
            return (S.transform.position - this.transform.position)
            .magnitude <= InteractionRadius;
        });
        if (SaveLoad != null)
        {
            SaveLoad.SaveLoadSystem.SavePlayerInfo(this);
        }
    }
    protected void HeightCheck()
    {
        if (Rigid.velocity.y < -0.1)
        {
            Height += 1;
            Animator.SetBool("IsFalling", true);
        }
    }
}
