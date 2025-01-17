using UnityEngine;
using System;
public class SoundEvents : MonoBehaviour
{
	public static event Action ActionJump;
	public static event Action ActionHit;
	public static event Action ActionDeath;
	public static event Action ActionWin;
	public static event Action ActionTramplinJump;
	public static event Action ActionEnemyAtack;
	public static event Action ActionStarsSparkling;
	public static event Action ActionEat;
	public static event Action ActionLeaves;
	public static event Action ActionWalk;
	public static event Action ActionStartGame;
	public static event Action ActionHowling;
	public static event Action ActionPausedMusic;
	public static event Action ActionUnPausedMusic;
	public static event Action ActionMiniWaterSplash;
	public static event Action ActionBigEnteriWaterSplash;
	public static event Action ActionBigExitWaterSplash;

	public static event Action ActionChangeMusicVolume;
	public static event Action ActionChangeSoundVolume;
	public static event Action ActionChangeWalkVolume;
	public static event Action ActionChangeBackVolume;
	
	public static void SetActionMiniWaterSplash()
	{
		ActionMiniWaterSplash?.Invoke();
	}
	public static void SetActionBigEnteriWaterSplash()
	{
		ActionBigEnteriWaterSplash?.Invoke();
	}
	public static void SetActionBigExitWaterSplash()
	{
		ActionBigExitWaterSplash?.Invoke();
	}
	public static void SetActionJump()
	{
		ActionJump?.Invoke();
	}
	public static void SetActionHit()
	{
		ActionHit.Invoke();
	}
	public static void SetActionDeath()
	{
		ActionDeath.Invoke();
	}
	public static void SetActionWin()
	{
		ActionWin.Invoke();
	}
	public static void SetActionTramplinJump()
	{
		ActionTramplinJump.Invoke();
	}
	public static void SetActionEnemyAtack()
	{
		ActionEnemyAtack.Invoke();
	}
	public static void SetMusicVolume()
	{
		ActionChangeMusicVolume.Invoke();
	}
	public static void SetSoundVolume()
	{
		ActionChangeSoundVolume.Invoke();
	}
	public static void SetChangeWalkVolume()
	{
		ActionChangeWalkVolume.Invoke();
	}
	public static void SetChangeBackVolume()
	{
		ActionChangeBackVolume.Invoke();
	}
	public static void SetActionStarsSparkling()
	{
		ActionStarsSparkling.Invoke();
	}
	public static void SetActionEat()
	{
		ActionEat.Invoke();
	}
	public static void SetActionLeaves()
	{
		ActionLeaves.Invoke();
	}
	public static void SetActionWalk()
	{
		ActionWalk.Invoke();
	}
	public static void SetActionStartGame()
	{
		ActionStartGame.Invoke();
	}
	public static void SetActionHowling()
	{
		ActionHowling.Invoke();
	}
	public static void SetActionPausedMusic()
	{
		ActionPausedMusic?.Invoke();
	}
	public static void SetActionUnPausedMusic()
	{
		ActionUnPausedMusic?.Invoke();
	}

}
