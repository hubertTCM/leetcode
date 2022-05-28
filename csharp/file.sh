#!/usr/bin/env bash
#chmod u+x file.sh
#touch $1.cs
cat > $1.cs <<EOF

using System;
using System.Collections.Generic;
using System.Linq;
namespace $1
{
    public class Solution
    {
    }

    public class Test
    {
        public static void Run()
        {
            var s = new Solution();
            Console.WriteLine("");
        }
    }
}
