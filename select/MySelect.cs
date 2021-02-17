using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MySelect
{
    public class MySelect
    {

        [Test]
        public void Select_Name()
        {
            var people = new List<Person>
            {
                new Person() {Name = "AA", Age = 47,Gender="M"},
                new Person() {Name = "BB", Age = 27,Gender="F"},
                new Person() {Name = "CC", Age = 37,Gender="M"},
            };

            var excepted = new List<string> { "AA", "BB", "CC" };

            Assert.AreEqual(excepted, MySelectMethod.CCSelct(people,p=>p.Name));
        }

        [Test]
        public void Select_Gender()
        {
            var people = new List<Person>
            {
                new Person() {Name = "AA", Age = 47,Gender="M"},
                new Person() {Name = "BB", Age = 27,Gender="F"},
                new Person() {Name = "CC", Age = 37,Gender="M"},
            };

            var excepted = new List<string> { "M", "F", "M" };

            Assert.AreEqual(excepted, MySelectMethod.CCSelct(people,p=>p.Gender));
        }

        [Test]
        public void Select_Age()
        {
            var people = new List<Person>
            {
                new Person() {Name = "AA", Age = 47,Gender="M"},
                new Person() {Name = "BB", Age = 27,Gender="F"},
                new Person() {Name = "CC", Age = 37,Gender="M"},
            };

            var excepted = new List<int> {47, 27, 37 };

            Assert.AreEqual(excepted, MySelectMethod.CCSelct(people, p => p.Age));
        }

        [Test]
        public void Select_NameAndAge()
        {
            var people = new List<Person>
            {
                new Person() {Name = "AA", Age = 47,Gender="M"},
                new Person() {Name = "BB", Age = 27,Gender="F"},
                new Person() {Name = "CC", Age = 37,Gender="M"},
            };

            var excepted = new List<Person>
            {
                new Person() {Name = "AA", Age = 47},
                new Person() {Name = "BB", Age = 27},
                new Person() {Name = "CC", Age = 37},
            };
            var result = MySelectMethod.CCSelct(people, p => new Person() { Name = p.Name, Age = p.Age });

            Assert.AreEqual(excepted, result);
        }

        [Test]
        public void Select_Other_Class()
        {
            var people = new List<MathScore>
            {
                new MathScore() {Name = "DD", Score = 100},
                new MathScore() {Name = "EE", Score = 60},
                new MathScore() {Name = "FF", Score = 10},

            };

            var excepted = new List<int> { 100, 60, 10 };
            var result = MySelectMethod.CCSelct(people, c => c.Score);

            Assert.AreEqual(excepted, result);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public override bool Equals(object obj)
        {
            var a = (Person)obj;
            return this.Name == a.Name && this.Age == a.Age && this.Gender == a.Gender;
        }
    }

    public class MathScore
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public override bool Equals(object obj)
        {
            var a = (MathScore)obj;
            return this.Name == a.Name && this.Score == a.Score;
        }
    }

    public static class MySelectMethod
    {
        public static IEnumerable<TResult> CCSelct<TSource, TResult>(IEnumerable<TSource> sources, Func<TSource, TResult> selector)
        {         
            foreach (var i in sources)
             yield return selector(i);
        }       
    }
}