using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnEnemyBase
{
	[HideInInspector] public bool shotFlag;//���C���X�^���X�����瑦��~����p��bool
	public GameObject enemyPrefab;
	public Vector2 pos = new Vector2(0, 550);
	public int time;

	[Header("HopDownEnemy�p")]
	public bool needInitHopDownEnemyFlag;
	public HopDownEnemyVariable hopDownEnemyVariable;

	[Header("GoCircleEnemy�p")]
	public bool needInitGoCircleEnemyFlag;
	public GoCircleEnemyVariable goCircleEnemyVariable;

	[Space]
	public bool makeSpecialBullet;
	public List<SpawnOneBulletBase> spawnOneBullets = new List<SpawnOneBulletBase>();
	public bool bulletLoopFlag;

}

[System.Serializable]
public class HopDownEnemyVariable
{
	public Vector2 goPos = new Vector2(0, 550);
}

[System.Serializable]
public class GoCircleEnemyVariable
{
	public int r;
	public float angle;//�����p�x�ʒu�B
	public float modificationToEllipse = 1;//�ȉ~�ό`�ϐ��B�ȉ~��ɓ������ꍇ�A�����̒l��ύX����B1�����ŉ����A1�ȏ�ŏc����ɓ���
}