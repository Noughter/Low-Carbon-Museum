using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
	public class StickRotation : MonoBehaviour
	{
		public SteamVR_Action_Boolean rotateAction;

		public Hand hand;


		private void OnEnable()
		{
			if (hand == null)
				hand = this.GetComponent<Hand>();

			if (rotateAction == null)
			{
				Debug.LogError("No rotation action assigned");
				return;
			}

			rotateAction.AddOnChangeListener(OnRotateActionChange, hand.handType);
		}

		private void OnDisable()
		{
			if (rotateAction != null)
				rotateAction.RemoveOnChangeListener(OnRotateActionChange, hand.handType);
		}

		private void OnRotateActionChange(SteamVR_Action_In actionIn)
		{
			if (rotateAction.GetStateDown(hand.handType))
			{
				Rotate();
			}
		}

		public void Rotate()
		{
			Player player = Player.instance;

			player.transform.rotation *= Quaternion.Euler(0, 90, 0);


		}

		/*private IEnumerator DoRotation()
		{
			Player player = Player.instance;

			player.transform.rotation = Quaternion.Euler(0, 90, 0);
		}*/
	}
}