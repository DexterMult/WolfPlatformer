using UnityEngine;

public class Mayatnik : MonoBehaviour
{
	public HingeJoint2D hingeJoint2D;
	private void SetMotorSpeed(float speed)
	{
		// Получаем текущий мотор
		JointMotor2D motor = hingeJoint2D.motor;

		// Изменяем скорость мотора
		motor.motorSpeed = speed;
		// Устанавливаем обновленный мотор обратно в hingeJoint2D
		hingeJoint2D.motor = motor;
	}
	void Update()
	{
		float currentRotationZ = transform.rotation.eulerAngles.z;

		// Проверяем условия для изменения скорости мотора
		if (currentRotationZ >= 170f)
		{
			SetMotorSpeed(90f); // Устанавливаем скорость мотора на 50
		}
		else if (currentRotationZ <= 10f)
		{
			SetMotorSpeed(-90); // Устанавливаем скорость мотора на -50
		}
	}
}
