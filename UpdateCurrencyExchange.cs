﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDataDragons
{
    public class UpdateCurrencyExchange
    {
            public double ExchangeRate;
            public void UpdateExchangeRate()  // updates the exchange rate
            {
                Console.WriteLine("Enter the updated exchange rate: ");
                ExchangeRate = double.Parse(Console.ReadLine());
            }
    }
}