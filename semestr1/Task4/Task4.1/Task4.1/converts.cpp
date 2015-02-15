void convertToBinary(int number, bool* array)
{
	if (number < 0)
	{
		array[0] = true;
		number = -number;
	}
	else
	{
		array[0] = false;
	}
	for (int i = 30; i >= 0; --i)
	{
		if (number - (1 << i) >= 0)
		{
			array[31 - i] = true;
			number = number - (1 << i);
		}
		else
		{
			array[31 - i] = false;
		}
	}
}

int convertToDecimal(bool* array)
{
	int result = 0;
	for (int i = 1; i < 32; ++i)
	{
		if (array[i])
		{
			result = result + (1 << (31 - i));
		}
	}
	if (array[0])
	{
		result = -result;
	}
	return result;
}