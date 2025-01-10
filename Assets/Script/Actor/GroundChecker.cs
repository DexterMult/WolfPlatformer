using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
	private Collider2D collider2;
	private Collider2D collidPlatform;
	private bool isDamageReturnPermisssion;
	private bool isGhostReturnPermisssion;

	[Header("Поверхность")]
	public bool isGround;
	public bool isPStandart;
	public bool isPOneWey;
	public bool isFall;

	[Header("Прыжок")]
	public bool isJump;
	public bool isJumpUP;

	[Header("Бой")]
	public bool isDeath;
	public bool isKickFall;
	public bool isDamage;
	public bool isGhost;
	public bool isEnemyRight;
	public bool isEnemyLeft;
	public bool isEnemyUp;
	public bool isEnemyDown;

	private bool playSoundDeathPermission; //разрешение воспроизвести звук смерти
	private bool playSoundHitPermission; //разрешение воспроизвести звук получения урона
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ground0"))
		{
			isFall = false;
			isJump = false;
			isGround = true;
			isJumpUP = false;
		}

		if (collision.CompareTag("PlatformTag"))
		{
			isFall = false;
			isJump = false;
			isPStandart = true;
			isJumpUP = false;
		}

		if (collision.CompareTag("POneWayTag"))
		{
			collidPlatform = collision.GetComponent<Collider2D>();
		}

	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ground0") && isJumpUP == false)
		{
			isGround = false;
			IsFallChecker();
		}
		if (collision.CompareTag("PlatformTag") && isJumpUP == false)
		{
			isPStandart = false;
			IsFallChecker();
		}
		if (collision.CompareTag("POneWayTag") && isJumpUP == false)
		{
			isPOneWey = false;
			IsFallChecker();
		}
	}

	private void IsFallChecker()
	{

		if (!isJump && !isKickFall && !isJumpUP)
		{
			isFall = true;
		}
	}

	private void POneWeyChecker()
	{

		if (collidPlatform == null || collider2 == null)
		{
			return;
		}
		isPOneWey = ((collider2.bounds.min.y - collidPlatform.bounds.max.y) < 0.1 && (collider2.bounds.min.y - collidPlatform.bounds.max.y) > 0);

		if (isPOneWey == true)
		{
			if (isJump == true)
				isJump = false;
			if (isFall == true)
				isFall = false;
			if (isJumpUP == true)
				isJumpUP = false;

			collidPlatform = null;
		}
	}

	private IEnumerator SetIsDamageFalse()
	{
		if (isDamage == true)
		{
			isDamageReturnPermisssion = false;
			yield return new WaitForSeconds(0.3f);
			isDamage = false;
			isDamageReturnPermisssion = true;
		}
	}
	private void CheckIsDamage()
	{
		if (isDamageReturnPermisssion == false)
		{
			return;
		}
		StartCoroutine(SetIsDamageFalse());
	}


	private IEnumerator SetIsGhostFalse()
	{
		if (isGhost == true)
		{
			isGhostReturnPermisssion = false;
			yield return new WaitForSeconds(2f);
			isGhost = false;
			isGhostReturnPermisssion = true;
		}
	}
	private void CheckIsGhost()
	{
		if (isGhostReturnPermisssion == false)
		{
			return;
		}
		StartCoroutine(SetIsGhostFalse());
	}

	private void CheckIsKickFall()
	{
		if ((Input.anyKey && isKickFall == true) || (!isDamage && (isGround || isPStandart || isPOneWey)))
		{
			isKickFall = false;
			if (!isGround && !isPStandart && !isPOneWey)
			{
				isFall = true;
			}
		}
	}

	public void SetIsDamageHorizontalSide(Vector2 actorPosition, Vector2 enemyPosition)
	{
		if (actorPosition.x <= enemyPosition.x)
		{
			isEnemyRight = true;
		}
		else if (actorPosition.x > enemyPosition.x)
		{
			isEnemyLeft = true;
		}
	}
	public void SetIsDamage(bool isDamage)
	{
		this.isDamage = isDamage;
	}

	public void SetIsGhost(bool isGhost)
	{
		this.isGhost = isGhost;
	}
	public void SetJump(bool jumpState)
	{
		isJump = jumpState;
	}
	public void SetFall(bool fall)
	{
		isFall = fall;
	}

	public void SetJumpUp(bool jumpState)
	{
		isJumpUP = jumpState;
	}
	public void SetisPOneWey(bool isPOneWeyState)
	{
		isPOneWey = isPOneWeyState;
	}
	public void SetIsEnemyRight(bool isEnemyRight)
	{
		this.isEnemyRight = isEnemyRight;
	}
	public void SetIsEnemyLeft(bool isEnemyLeft)
	{
		this.isEnemyLeft = isEnemyLeft;
	}
	public void SetIsKickFall(bool isKickFall)
	{
		this.isKickFall = isKickFall;
	}
	private void PlayeSoundDeath()
	{
		if (isDeath == true && playSoundDeathPermission == true)
		{
			playSoundDeathPermission = false;
			SoundEvents.SetActionDeath();
		}
	}
	private void PlayeSoundHit()
	{
		if (isDamage == true && playSoundHitPermission == true)
		{
			SoundEvents.SetActionEnemyAtack();
			playSoundHitPermission = false;
		}
		else if (isDamage == false && playSoundHitPermission == false)
		{
			playSoundHitPermission = true;
		}
	}
	private void Start()
	{
		playSoundHitPermission = true;
		playSoundDeathPermission = true;
		isKickFall = false;
		isGhostReturnPermisssion = true;
		isDamageReturnPermisssion = true;
		isDamage = false;
		isGhost = false;
		isGround = false;
		isPStandart = false;
		isPOneWey = false;
		isFall = false;
		isJump = false;
		isDamage = false;
		isDeath = false;

		collider2 = GetComponent<Collider2D>();
	}

	private void Update()
	{
		POneWeyChecker();
		CheckIsGhost();
		CheckIsDamage();
		CheckIsKickFall();
		PlayeSoundDeath();
		PlayeSoundHit();
	}

}
