﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumHardware
{
  class Program
  {
    static void Main(string[] args)
    {
      Host host = new Host();

      host.ListComponents();

      Console.Read();




    }
  }
}
