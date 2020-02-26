
namespace MySpace
{
	void Subtraction(int& ref)
	{
		if (ref == 0)
			ref = -1;
		else
		{
			int Num_i;
			for (int mask = 0; mask < sizeof(int) * 8 - 1; mask++)
			{
				Num_i = ref & (1 << mask);
				if (Num_i > 0)
				{
					for (int i = 0; i < mask + 1; i++)
						ref = ref ^ (1 << i);
					break;
				}
			}
		}
	}
	bool Compare(int A, int B)
	{
		int Num_1, Num_2;
		bool flag = false;
		for (int mask = sizeof(int) * 8 - 1; mask >= 0; mask--)
		{
			Num_1 = A & (1 << mask);
			Num_2 = B & (1 << mask);
			if (Num_1 > Num_2)
			{
				flag = true;
				break;
			}
			else
				if (Num_1 < Num_2)
				{
					flag = false;
					break;
				}
		}
		return flag;
	}
}
