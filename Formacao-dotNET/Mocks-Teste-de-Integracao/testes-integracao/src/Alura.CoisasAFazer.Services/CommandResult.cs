﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.CoisasAFazer.Services
{
    public class CommandResult
    {
        public bool IsSuccess { get; }

        public CommandResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
