namespace Tests_Fractions {
    using Fractions;
    using System;

    [TestFixture]
    public class Class1 {

        [TestCase(5, 7)]
        [TestCase(3, 7)]
        [TestCase(-9, 55)]
        [TestCase(15,22)]
        [TestCase(5,3)]
        public void Constructor_BaseCase(int num, int den) {
            var f = new Fractions(num, den);
            Assert.Multiple(() => {
                Assert.That(f.Numerator, Is.EqualTo(num));
                Assert.That(f.Denominator, Is.EqualTo(den));
            });
        }

        [TestCase(2,4,1,2)]
        [TestCase(3, 6, 1, 2)]
        [TestCase(2, 2, 1, 1)]
        public void Reduction(int num, int den, int expectedNum, int expectedDen) {
            var f = new Fractions(num, den);
            Assert.Multiple((() => {
                Assert.That(f.Numerator, Is.EqualTo(expectedNum));
                Assert.That(f.Denominator, Is.EqualTo(expectedDen));
            }));
        }


        [TestCase(-15, 5, -3, 1)]
        [TestCase(3, -15, -1, 5)]
        [TestCase(-3, -12, 1, 4)]
        public void Reduction_WithNegativeNumber(int num, int den, int expectedNum, int expectedDen) {
            var f = new Fractions(num, den);
            Assert.Multiple((() => {
                Assert.That(f.Numerator, Is.EqualTo(expectedNum));
                Assert.That(f.Denominator, Is.EqualTo(expectedDen));
            }));
        }

        [TestCase(7)]
        [TestCase(-86)]
        [TestCase(0)]
        public void ZeroDenThrows(int num) {
            Assert.That(() => new Fractions(num, 0), Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(3, 5, 9, 5, 12, 5)]
        [TestCase(3, 4, 4, 4, 7, 4)]
        [TestCase(4, 5, 1, 6, 29, 30)]
        [TestCase(-4 * 3, 12, 1, -6, -7, 6)]
        [TestCase(3, 4, 5, 6, 19, 12)]
        public void Addition(int n1, int d1, int n2, int d2, int expectedN, int expectedD) {
            var f1 = new Fractions(n1, d1);
            var f2 = new Fractions(n2, d2);
            var result = f1 + f2;
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(expectedN));
                Assert.That(result.Denominator, Is.EqualTo(expectedD));
            });
        }


        [TestCase(3, 5, 9, 5, -6, 5)]
        [TestCase(3, 4, 4, 4, -1, 4)]
        [TestCase(4, 5, 1, 6, 19, 30)]
        [TestCase(-4 * 3, 12, 1, -6, -5, 6)]
        [TestCase(5, 6, 3, 4, 1, 12)]
        public void Subtraction(int n1, int d1, int n2, int d2, int expectedN, int expectedD) {
            var f1 = new Fractions(n1, d1);
            var f2 = new Fractions(n2, d2);
            var result = f1 - f2;
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(expectedN));
                Assert.That(result.Denominator, Is.EqualTo(expectedD));
            });
        }


        [TestCase(1, 2, 3, 4, 3, 8)]
        [TestCase(3, 5, 9, 5, 27, 25)]
        [TestCase(4, 5, 1, 6, 2, 15)]
        [TestCase(-12, 12, -1, 6, 1, 6)]
        [TestCase(3,5,7,6,7,10)]
        public void Multiplication(int n1, int d1, int n2, int d2, int expectedN, int expectedD) {
            var f1 = new Fractions(n1, d1);
            var f2 = new Fractions(n2, d2);
            var result = (f1 * f2);
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(expectedN));
                Assert.That(result.Denominator, Is.EqualTo(expectedD));
            });
        }


        [TestCase(3, 5, 7, 8, 24, 35)]
        [TestCase(1,2,1,3,3,2)]
        public void Division(int n1, int d1, int n2, int d2, int expectedN, int expectedD) {
            var f1 = new Fractions(n1, d1);
            var f2 = new Fractions(n2, d2);
            var result = f1 / f2;
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(expectedN));
                Assert.That(result.Denominator, Is.EqualTo(expectedD));
            });
        }

        [TestCase(1,2, "1/2")]
        [TestCase(2, 4, "1/2")]
        [TestCase(-1, 2, "-1/2")]
        [TestCase(7, -9, "-7/9")]
        public void Frac_To_String(int n, int d, string s) {
            var f = new Fractions(n, d);
            Assert.That(f.ToString(), Is.EqualTo(s));
        }
    }
}