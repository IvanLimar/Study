using System;

namespace Calculator
{
    /// <summary>
    /// Калькулятор. Поддерживает арифметические опеации.
    /// </summary>
    public class Calculator
    {
        private bool isPointButtonPressed = false;
        private bool isError = false;

        private const int length = 10;
        
        public string Result { get; set; }
        public string SecondOperand { get; set; }
        public string Operation { get; set; }

        public Calculator()
        {
            Result = "0";
            SecondOperand = "";
            Operation = "";
        }

        /// <summary>
        /// Изменяем число при нажатии на цифру.
        /// </summary>
        public void AddNumber(string number)
        {
            if (isError)
            {
                return;
            }
            if (Operation == "")
            {
                if (Result == "0")
                {
                    if (number == "0" && !isPointButtonPressed)
                    {
                        return;
                    }
                    Result = number;
                    return;
                }
                if (Result.Length == length)
                {
                    return;
                }
                Result = Result + number;
                return;
            }
            if (SecondOperand == "0" && number == "0" && !isPointButtonPressed)
            {
                return;
            }
            if (SecondOperand.Length == length)
            {
                return;
            }
            SecondOperand = SecondOperand + number;
        }

        /// <summary>
        /// Реакция на нажатие кнопок "+", "-" , "/" , "*"
        /// </summary>
        public void OperationButtonPresed(string operation)
        {
            if (isError)
            {
                return;
            }
            isPointButtonPressed = false;
            if (Operation == "" || SecondOperand == "")
            {
                Operation = operation;
                return;
            }
            Count();
            if (isError)
            {
                return;
            }
            Operation = operation;
        }

        /// <summary>
        /// Реагируем на кнопку "=".
        /// </summary>
        public void EaqualButtonPressed()
        {
            if (Operation == "" || SecondOperand == "" || isError)
            {
                return;
            }
            isPointButtonPressed = false;
            Count();
            if (isError)
            {
                return;
            }
            Operation = "";
        }

        /// <summary>
        /// Знак результата изменяется на противоположенный
        /// </summary>
        public void DenialButtonPressed()
        {
            if (isError || SecondOperand != "")
            {
                return;
            }
            if (Result[0] == '-')
            {
                Result = Result.Substring(1);
            }
            else
            {
                Result = "-" + Result;
            }
        }

        /// <summary>
        /// Очистка экрана
        /// </summary>
        public void ClearButtonPressed()
        {
            Result = "0";
            isError = false;
            isPointButtonPressed = false;
            Operation = "";
            SecondOperand = "";
        }

        /// <summary>
        /// Вводим дробную часть числа, если возможно.
        /// </summary>
        public void PointButttonPressed()
        {
            if (isError || isPointButtonPressed)
            {
                return;
            }
            if (Operation == "")
            {
                if (Result.Length == length - 1)
                {
                    return;
                }
                isPointButtonPressed = true;
                Result = Result + ",";
                return;
            }
            if (SecondOperand.Length == length - 1 || SecondOperand == "")
            {
                return;
            }
            isPointButtonPressed = true;
            SecondOperand = SecondOperand + ",";
        }

        private void Count()
        {
            decimal firstOperand = Convert.ToDecimal(Result);
            decimal secondOperand = Convert.ToDecimal(SecondOperand);
            decimal result = 0;
            switch (Operation)
            {
                case "+":
                    result = firstOperand + secondOperand;
                    break;
                case "-":
                    result = firstOperand - secondOperand;
                    break;
                case "*":
                    result = firstOperand * secondOperand;
                    break;
                case "/":
                    if (secondOperand == 0)
                    {
                        isError = true;
                        Result = "Error! Dividing by zero!";
                        return;
                    }
                    result = firstOperand / secondOperand;
                    break;
            }
            if (Math.Abs(result) > Convert.ToDecimal(Math.Pow(10, length) - 1))
            {
                isError = true;
                Result = "Error. Too big result.";
                return;
            }
            SecondOperand = "";
            Result = result.ToString();
            if (Result.Length > length)
            {
                Result = Result.Substring(0, length);
                if (Result[length - 1] == ',')
                {
                    Result =  Result.Remove(length - 1);
                }
            }
            if (result - Math.Truncate(result) != 0)
            {
                isPointButtonPressed = true;
            }
        }
    }
}
