using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [SerializeField] private float m_WaterJumpForce;							// Amount of force added when the player jumps in water.
    [SerializeField] private float doubleJumpForce;								// Amount of force added when the player double jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [Range(0, 2f)][SerializeField] private float m_IceMovementSmoothing = .3f;
    [SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private LayerMask m_WhatIsDeath;
    [SerializeField] private LayerMask m_WhatIsWater;
    [SerializeField] private LayerMask m_WhatIsIce;
    [SerializeField] private LayerMask m_WhatIsToKill;
    [SerializeField] private Transform m_GroundCheck;	// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_GroundCheck2;
	[SerializeField] private Transform m_GroundCheck3;
	[SerializeField] private Transform m_DeathCheck;
	[SerializeField] private Transform m_LeftWallCheck;
	[SerializeField] private Transform m_RightWallCheck;					
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Transform m_KillCheck;
    [SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching
	[SerializeField] private bool m_Grounded;
    [SerializeField] public bool inWater;
    [SerializeField] public bool doubleJumpNext;
    [SerializeField] private string lastSurface;
	[SerializeField] private bool onIce;
    [SerializeField] public float SpawnX;
    [SerializeField] public float SpawnY;
	public GameObject DeathObject;
	private bool wasWall;
	string preWall;
	public UnityEngine.GameObject collider1;
    public UnityEngine.GameObject collider2;
    public UnityEngine.GameObject collider3;
    public UnityEngine.GameObject colliderice;
    public UnityEngine.GameObject colliderIce2;
    public UnityEngine.GameObject colliderIce3;

    public Death dedCheck;

    private bool _glide = false;

    int groundCount = 0;


	const float k_GroundedRadius = .05f; // Radius of the overlap circle to determine if grounded
		const float k_DeadRadius = 0.6f;
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	const float k_WallRadius = .05f; 
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 velocity = Vector3.zero;
	public bool Wall = false;
	private bool leftInitiated = false;
	private bool rightInitiated = false;
	private bool _canJump = false;
	private bool checkValues = false;
	private bool canDash = false;
	public bool runGroundJumpAnimation;
	public bool runSwimJumpAnimation;
	public bool runDashAnimation;
    float dashX;
	float dashY;
	public bool runDoubleJumpAnimation;
	public float posX;
	public float posY;
	private bool left;
	private bool right;
    [SerializeField] private float wind;
	public bool NoWallJump;
	public bool isGliding;


    // this is an example of exposing a public property that exposes the veritical velocity to methods that have access to instances of this class
    // public float VerticalVelocity
    // {
    //    get { return m_Rigidbody2D.velocity.y; }
    // }

    private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

        
	private void FixedUpdate()
	{
		posX = m_Rigidbody2D.transform.position.x;
		posY = m_Rigidbody2D.transform .position.y;
		//Debug.Log("FixedUpdate");
		m_Grounded = false;
		inWater = false;
		onIce = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
            {
				collider1 = colliders[i].gameObject;
				// the character is touching the ground in the middle of the square
                groundCount = 6;
				canDash=true;
				m_Grounded = true;
				checkValues = true;
                //Debug.Log("collider middle");
                lastSurface = "ground";
                doubleJumpNext = false;
				wasWall = false;
				preWall = "nope";
            }

		}

		Collider2D[] colliders2 = Physics2D.OverlapCircleAll(m_GroundCheck2.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders2.Length; i++)
		{
			if (colliders2[i].gameObject != gameObject)
            {
                collider2 = colliders2[i].gameObject;
                // the character is touching the ground in the right of the square
                groundCount = 6;
				canDash=true;
				m_Grounded = true;
				checkValues = true;
				//Debug.Log("collider right");
                lastSurface = "ground";
                doubleJumpNext = false;
				wasWall = false;
				preWall = "nope";
            }
		}

		Collider2D[] colliders3 = Physics2D.OverlapCircleAll(m_GroundCheck3.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders3.Length; i++)
		{
			if (colliders3[i].gameObject != gameObject)
            {
                collider3 = colliders3[i].gameObject;
                // the character is touching the ground in the left of the square
                groundCount = 6;
				canDash=true;
				m_Grounded = true;
				checkValues = true;
				//Debug.Log("collider left");
				lastSurface = "ground";
                doubleJumpNext = false;
                wasWall = false;
				preWall = "nope";
            }
		}
        Collider2D[] waterColliders1 = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsWater);
        for (int i = 0; i < waterColliders1.Length; i++)
        {
            if (waterColliders1[i].gameObject != gameObject)
            {
                // the character is touching water in the middle of the square
                inWater = true;
            }

        }

        Collider2D[] waterColliders2 = Physics2D.OverlapCircleAll(m_GroundCheck2.position, k_GroundedRadius, m_WhatIsWater);
        for (int i = 0; i < waterColliders2.Length; i++)
        {
            if (waterColliders2[i].gameObject != gameObject)
            {
                // the character is touching water in the right of the square
                inWater = true;
            }
        }

        Collider2D[] waterColliders3 = Physics2D.OverlapCircleAll(m_GroundCheck3.position, k_GroundedRadius, m_WhatIsWater);
        for (int i = 0; i < waterColliders3.Length; i++)
        {
            if (waterColliders3[i].gameObject != gameObject)
            {
                // the character is touching water in the left of the square
                inWater = true;
            }
        }
        Collider2D[] iceColliders1 = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsIce);
        for (int i = 0; i < iceColliders1.Length; i++)
        {
            if (iceColliders1[i].gameObject != gameObject)
            {
				colliderice = iceColliders1[i].gameObject;
				// the character is touching ice in the middle of the square
				onIce = true;
                groundCount = 6;
                canDash = true;
                m_Grounded = true;
                checkValues = true;
                lastSurface = "ice";
                doubleJumpNext = false;
                wasWall = false;
                preWall = "nope";
            }

        }

        Collider2D[] iceColliders2 = Physics2D.OverlapCircleAll(m_GroundCheck2.position, k_GroundedRadius, m_WhatIsIce);
        for (int i = 0; i < iceColliders2.Length; i++)
        {
            if (iceColliders2[i].gameObject != gameObject)
            {
                colliderIce2 = iceColliders2[i].gameObject;
                // the character is touching ice in the right of the square
                onIce = true;
                groundCount = 6;
                canDash = true;
                m_Grounded = true;
                checkValues = true;
                lastSurface = "ice";
                doubleJumpNext = false;
                wasWall = false;
                preWall = "nope";
            }
        }

        Collider2D[] iceColliders3 = Physics2D.OverlapCircleAll(m_GroundCheck3.position, k_GroundedRadius, m_WhatIsIce);
        for (int i = 0; i < iceColliders3.Length; i++)
        {
            if (iceColliders3[i].gameObject != gameObject)
            {
                colliderIce3 = iceColliders3[i].gameObject;
                // the character is touching ice in the left of the square
                onIce = true;
                groundCount = 6;
                canDash = true;
                m_Grounded = true;
                checkValues = true;
                lastSurface = "ice";
                doubleJumpNext = false;
                wasWall = false;
                preWall = "nope";
            }
        }
		Debug.Log("1: " + collider1 + " 2: " + collider2 + " 3: " + collider3 + " ice1: " + colliderice + " ice2: " + colliderIce2 + " ice3: " + colliderIce3);
        // Check if the player has collided with Dead
        Collider2D[] deathColliders = Physics2D.OverlapCircleAll(m_DeathCheck.position, k_DeadRadius, m_WhatIsDeath);
		for (int i = 0; i < deathColliders.Length; i++)
		{
                if (deathColliders[i].gameObject != gameObject)
            {
                dedCheck._ded = true;
            }
		}
        Collider2D[] killColliders = Physics2D.OverlapCircleAll(m_KillCheck.position, k_DeadRadius, m_WhatIsToKill);
        for (int i = 0; i < killColliders.Length; i++)
        {
            
            if (killColliders[i].gameObject != gameObject)
			{
				Debug.Log(killColliders[i].gameObject + "orig game object");
				DeathObject = killColliders[i].gameObject;
            }
        }

        //Check if the player is touching the left wall
        Wall = false;
		Collider2D[] leftColliders = Physics2D.OverlapCircleAll(m_LeftWallCheck.position, k_WallRadius, m_WhatIsGround);
		for (int i = 0; i < leftColliders.Length; i++)
		{
			if (leftColliders[i].gameObject != gameObject)
            {
                Wall = true;
				wasWall = true;
				//Debug.Log("Right Wall");
				if (m_FacingRight == true)
				{
					left = true;
					right = false;
				}
				if (m_FacingRight == false) 
				{ 
					right = true;
					left = false;
				}
				
            } 

		}
		// set values
		if (m_Grounded == false && checkValues)
		{
			dashX = m_Rigidbody2D.velocity.x*2;
			dashY = m_Rigidbody2D.velocity.y;
			checkValues = false;
		}

		// allows us to pretend we are on the ground for 6 method calls
        if (groundCount >= 1)
        {
            _canJump = true;
        }
		else
		{
			_canJump = false;
		}
		if (groundCount == 0 && Wall == false && wasWall == false)
		{
			doubleJumpNext = true;
		}

        groundCount = groundCount - 1;

		// determine gravity value
        if (m_Grounded == true && Wall == true)
		{
			NoWallJump = true;
		}
		if (Wall == false)
		{
			NoWallJump = false;
		}
	}


	public void Move(float move, bool crouch, bool jump, bool glide, bool dash, bool InitiateWall)
	{
		if (m_Rigidbody2D.velocity.y < 0)
		{
			isGliding = glide;
		} else
		{
			isGliding = false;
		}
        if (dedCheck._ded)
        {
            transform.position = new Vector2(SpawnX, SpawnY);
            m_Rigidbody2D.velocity = new Vector2(0f, 0f);

        }
        _glide = glide;
		if (Wall && m_FacingRight == false && right == false) 
		{
			Wall = false;
        }
        if (Wall && m_FacingRight == true && left == false)
        {
			Wall = false;
        }

		if (inWater)
		{
			m_Rigidbody2D.gravityScale = 1;
		}
		else if (Wall == true && NoWallJump == false)
		{
			m_Rigidbody2D.gravityScale = 0;
			m_Rigidbody2D.velocity = new Vector2(0f, -1f);
			groundCount = 0;
		}
		else if (glide == true && m_Rigidbody2D.velocity.y < 0 && (Wall == false || Wall == true && NoWallJump))
		{
			// gliding while falling down sets the gravity to 1
			m_Rigidbody2D.gravityScale = 1;
		}
        else
        {
            m_Rigidbody2D.gravityScale = 3;
        }




        
		// If crouching, check to see if the character can stand up
		if (crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//if dashing, and we can dash, dash
		if (dash && canDash && m_Grounded == false && inWater == false)
		{
			m_Rigidbody2D.velocity = new Vector2(dashX, dashY);
			canDash = false;
			runDashAnimation = true;
        }

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{
			// If crouching
			if (crouch)
			{
				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			}
			else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f - wind, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			if (lastSurface == "ground" || inWater)
			{
				m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);
			} else if (lastSurface == "ice")
			{
				m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_IceMovementSmoothing);
			}
			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (_canJump && jump && inWater == false && ((Wall == false) || (Wall == true && NoWallJump)))
		{
			// Add a vertical force to the player.
			_canJump = false;
			groundCount = 0;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			Debug.Log("normalJump");
			doubleJumpNext = true;
			runGroundJumpAnimation = true;


        } else if (inWater == false && doubleJumpNext && jump)
		{
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, doubleJumpForce);
			doubleJumpNext = false;
			Debug.Log("double jump");
            runDoubleJumpAnimation = true;
        } else if (jump && inWater == true) {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, m_WaterJumpForce);
			runSwimJumpAnimation = true;
        }
		if (InitiateWall && Wall && inWater == false && m_FacingRight == false)
		{
			if (wasWall && preWall == "right")
			{
				m_Rigidbody2D.AddForce(new Vector2(900f, 400f));
			}
			else
			{
                m_Rigidbody2D.AddForce(new Vector2(900f, 600f));
            }
			preWall = "right";
			
		}
		if (InitiateWall && Wall && inWater == false && m_FacingRight == true)
		{
            if (wasWall && preWall == "left")
            {
                m_Rigidbody2D.AddForce(new Vector2(-900f, 400f));
            }
            else
            {
                m_Rigidbody2D.AddForce(new Vector2(-900f, 600f));
            }
			preWall = "left";

		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
