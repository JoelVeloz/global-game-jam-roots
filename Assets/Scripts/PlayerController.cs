using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    public AudioClip jumpAudio;
    public AudioClip respawnAudio;
    public AudioClip ouchAudio;
*/
    
   /*
    public AudioSource audioSource;
    public Health health;
    */
    public bool controlEnabled = true;

    //public Collider2D collider2d;
    private Rigidbody2D rigidbody2d;

    [Header("Movimiento")]
    private float horizontalmovement = 0f;
    public float maxSpeed; //velocidad de movimiento
    public float smoothSpeed; // suavizado de movimiento
    private Vector3 speed = Vector3.zero;
    private bool lookingRight = true;
    //public float jumpTakeOffSpeed = 7;

    [Header("Salto")]
    [SerializeField] private float jumpStrength; // fuerza Salto
    [SerializeField] private LayerMask ground; //queEsSue10
    [SerializeField] private Transform groundController ; //controladorSueIo
    [SerializeField] private Vector3 boxDimensions; //di•ensionescaja
    [SerializeField] private bool onground; //enSuelo
    private bool jump = false;

    [Header("Animación")]
    private Animator animator;

/*
    bool jump;
    Vector2 move;
    SpriteRenderer spriteRenderer;
    internal Animator animator;
    //readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();
    public Bounds Bounds => collider2d.bounds;
    */
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (controlEnabled)
        {
            horizontalmovement = Input.GetAxis("Horizontal") * maxSpeed;
            animator.SetFloat("Horizontal", Mathf.Abs(horizontalmovement));
            animator.SetFloat("Speed",rigidbody2d.velocity.y);
            if (Input.GetButtonDown("Jump")){
                jump = true;
            }
        }
        else
        {
            horizontalmovement = 0;
        }
        //UpdateJumpState();
        //base.Update();
    }

    private void FixedUpdate(){
        onground = Physics2D.OverlapBox(groundController.position, boxDimensions, 0f, ground);
        animator.SetBool("onGround",onground);
        Moving(horizontalmovement*Time.fixedDeltaTime, jump);
        jump = false;
    }

    private void Moving(float moving, bool jumping) //mover
    {
        Vector3 aimSpeed = new Vector2(moving,rigidbody2d.velocity.y);
        rigidbody2d.velocity = Vector3.SmoothDamp(rigidbody2d.velocity, aimSpeed, ref speed,smoothSpeed);

        if(moving > 0 && !lookingRight)
        {
            //Girar
            Flip();
        }else if(moving<0 && lookingRight){
            //Girar
            Flip();
        }

        if(onground && jumping){
            onground = false;
            rigidbody2d.AddForce(new Vector2(0f, jumpStrength));

        }

    }

    private void Flip(){
        lookingRight = !lookingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale =scale;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundController.position,boxDimensions);
    }
/*
    void UpdateJumpState()
    {
        jump = false;
        switch (jumpState)
        {
            case JumpState.PrepareToJump:
                jumpState = JumpState.Jumping;
                jump = true;
                stopJump = false;
                break;
            case JumpState.Jumping:
                if (!IsGrounded)
                {
                    Schedule<PlayerJumped>().player = this;
                    jumpState = JumpState.InFlight;
                }
                break;
            case JumpState.InFlight:
                if (IsGrounded)
                {
                    Schedule<PlayerLanded>().player = this;
                    jumpState = JumpState.Landed;
                }
                break;
            case JumpState.Landed:
                jumpState = JumpState.Grounded;
                break;
        }
    }

    protected override void ComputeVelocity()
    {
        if (jump && IsGrounded)
        {
            velocity.y = jumpTakeOffSpeed * model.jumpModifier;
            jump = false;
        }
        else if (stopJump)
        {
            stopJump = false;
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * model.jumpDeceleration;
            }
        }

        if (move.x > 0.01f)
            spriteRenderer.flipX = false;
        else if (move.x < -0.01f)
            spriteRenderer.flipX = true;

        animator.SetBool("grounded", IsGrounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    public enum JumpState
    {
        Grounded,
        PrepareToJump,
        Jumping,
        InFlight,
        Landed
    }
    */
}
