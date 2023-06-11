using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
	public GameObject bulletPrefab;
	[HideInInspector] public bool shootingFlag;
	public bool chargeMode;
	protected int waitTimer;//�N�[���^�C�����߂������ǂ����̃^�C�}�[�B0�̎��͔��ˉ\
	[SerializeField] int waitTime;//�N�[���^�C��
	protected bool chargeFlag;//�`���[�W���[�h���I���ɂ��邩
	[SerializeField] int chargeTime;//�`���[�W���[�h�I�����A�`���[�W�������ǂ�قǑ҂�  
	protected AudioSource audioSource;
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		shootingFlag = false;
	}
	public void StartTimer()
	{
		waitTimer++;
	}
	protected void ShotFixedUpdate()//�ʁX��fixedupdate�͌Ăяo���Ȃ��̂ŁA�q�N���X�ɂ���Ă��炤
	{
		if(waitTimer != 0)
		{
			if(waitTimer >= waitTime)
			{
				waitTimer = 0;
			}
			else
			{
				waitTimer++;
			}
		}
	}
}
