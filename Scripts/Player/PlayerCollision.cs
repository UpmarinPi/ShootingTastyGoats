using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Consts;

public class PlayerCollision : MonoBehaviour
{
	GameObject parentGO;
	PlayerDeath playerDeath;//�e�I�u�W�F�N�g�ɂ���playerdeath���Q��

	public int hp;
	[SerializeField] float invincibleTime;//���G����
	float invincibleTimer;//�^�C�}�[�B�����ł͖��G���Ԕ������ɊJ�n����
	public bool invincibleFlag;
	[SerializeField] Color32 showColor;
	SpriteRenderer spriteRenderer;
	KeyCode slowKey1 = ConstClass.slowkey1;
	KeyCode slowKey2 = ConstClass.slowkey2;
	[Space]
	AudioSource audioSource;
	[SerializeField] AudioClip goatCrySound;
	[SerializeField] AudioClip damagedSound;

	[SerializeField] GoatUIDamaged goatuiDamaged;
	void Start()
	{
		invincibleTimer = 0;
		parentGO = this.transform.parent.gameObject;
		playerDeath = parentGO.GetComponent<PlayerDeath>();

		spriteRenderer = transform.GetComponent<SpriteRenderer>();
		audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		if(invincibleFlag)
		{
			if(invincibleTime / 100.0f <= invincibleTimer)
			{
				invincibleTimer = 0;
				invincibleFlag = false;
			}
			invincibleTimer += Time.deltaTime;
		}

	}
	private void FixedUpdate()
	{
		if(playerDeath.deathFlag)
		{
			return;
		}
		if(Input.GetKey(slowKey1) || Input.GetKey(slowKey2))//slowKey�������Ă���Ԃ͒x���Ȃ�
		{
			spriteRenderer.color = showColor;
		}
		else
		{
			spriteRenderer.color = new Color32(255, 255, 255, 0);
		}

	}
	private void OnTriggerEnter2D(Collider2D trigger)
	{
		if(trigger.CompareTag("Enemy"))
		{
			Damaged();
		}
	}
	void Damaged()//�_���[�W���󂯂��Ƃ��̓���B0�Ȃ玀�S�B1�ȏ�Ȃ��莞�Ԗ��G�ɂȂ��Đ����c��
	{
		if(!invincibleFlag)
		{
			if(hp <= 0)
			{
				playerDeath.deathFlag = true;
			}
			else
			{
				audioSource.PlayOneShot(goatCrySound);
				audioSource.PlayOneShot(damagedSound);
				goatuiDamaged.damagedFlag = true;
				invincibleFlag = true;
				hp--;
			}
		}
	}
}
