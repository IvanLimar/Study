void positiveSum(bool* array1, bool* array2, bool* arrayResult)
{
	arrayResult[0] = array1[0];
	bool additionalOne = false;
	for (int i = 31; i >= 1; --i)
	{
		if (additionalOne)
		{
			if (array1[i])
			{
				if (array2[i])
				{
					arrayResult[i] = true;
					additionalOne = true;
				}
				else
				{
					arrayResult[i] = false;
					additionalOne = true;
				}
			}
			else
			{
				if (array2[i])
				{
					arrayResult[i] = false;
					additionalOne = true;
				}
				else
				{
					arrayResult[i] = true;
					additionalOne = false;
				}
			}
		}
		else
		{
			if (array1[i])
			{
				if (array2[i])
				{
					arrayResult[i] = false;
					additionalOne = true;
				}
				else
				{
					arrayResult[i] = true;
					additionalOne = false;
				}
			}
			else
			{
				if (array2[i])
				{
					arrayResult[i] = true;
					additionalOne = false;
				}
				else
				{
					arrayResult[i] = false;
					additionalOne = false;
				}
			}
		}
	}
}

void negativeSum(bool* array1, bool* array2, bool* arrayResult)
{
	arrayResult[0] = array1[0];
	for (int i = 31; i >= 1; --i)
	{
		if (array1[i] == array2[i])
		{
			arrayResult[i] = false;
		}
		else
		{
			if (array1[i] && !array2[i])
			{
				arrayResult[i] = true;
			}
			if (!array1[i] && array2[i])
			{
				arrayResult[i] = true;
				for (int j = i - 1; j >= 1; --j)
				{
					if (array1[j])
					{
						array1[j] = false;
						for (int k = j + 1; k <= i - 1; ++k)
						{
							array1[k] = true;
						}
						break;
					}
				}
			}
				
		}
	}
}

void binarySum(bool* array1, bool* array2, bool* arrayResult)
{
	if (array1[0] == array2[0])
	{
		positiveSum(array1, array2, arrayResult);
	}
	else
	{
		negativeSum(array1, array2, arrayResult);
	}
}