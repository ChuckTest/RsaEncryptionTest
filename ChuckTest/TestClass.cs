using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ChuckTest
{
    //https://www.cnblogs.com/chucklu/p/5309297.html
    //https://www.cnblogs.com/chucklu/p/5197231.html
    [TestFixture]
    public class TestClass
    {

        //encrypt by public key, and decrypt by private key
        [Test]
        public void Test2021_1214_001()
        {
            //p=3, q=11
            //n=p*q=33
            //φ(n)=(p-1)*(q-1)=2*10=20
            //e = 7, 1<e<φ(n)
            //ed-1=kφ(n) => d=3 (ed-1=φ(n)) 3*7-1=1*20
            //public key(e,n)=>(7,33)
            //private key(d,n)=>(3,33)
            var e = new BigInteger(7);
            var d = new BigInteger(3);
            var n = new BigInteger(33);

            //encrypt m, then m^e = c (mod n) //=> m^7 = c (mod 33)
            // (bnData ^ Exponent) % Modulus - This Encrypt the data using the public Exponent
            var m = new BigInteger(2);
            BigInteger c = BigInteger.ModPow(m,e, n);
            Console.WriteLine(c);

            //c^d = m (mod n), 也就是说，c的d次方除以n的余数为m。
            BigInteger m1 = BigInteger.ModPow(c, d, n);
            Console.WriteLine(m1);
        }

        //encrypt by private key, and decrypt by public key
        [Test]
        public void Test2021_1214_002()
        {
            //p=3, q=11
            //n=p*q=33
            //φ(n)=(p-1)*(q-1)=2*10=20
            //e = 7, 1<e<φ(n)
            //ed-1=kφ(n) => d=3 (ed-1=φ(n)) 3*7-1=1*20
            //public key(e,n)=>(7,33)
            //private key(d,n)=>(3,33)
            var e = new BigInteger(7);
            var d = new BigInteger(3);
            var n = new BigInteger(33);
            
            var m = new BigInteger(2);
            BigInteger c = BigInteger.ModPow(m, d, n);
            Console.WriteLine(c);
            
            BigInteger m1 = BigInteger.ModPow(c, e, n);
            Console.WriteLine(m1);
        }
    }
}
