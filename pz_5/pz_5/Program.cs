using System;

namespace pz_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee("Смирнов Семён Петрович", 26);
            Employee e2 = (Employee)e1.Clone();
            Console.WriteLine(e1.CompareTo(e2));
            Console.WriteLine(e2.ToString());
            Console.ReadKey();
        }
    }
        internal class Employee : ICloneable, IComparable<Employee>
        {
            private string FIO { get; set; }
            private int Age { get; set; }
            public Employee(string fio, int age)
            {
                FIO = fio;
                Age = age;
            }
            public object Clone()
            {
                return new Employee(this.FIO, this.Age);
            }
            public int CompareTo(Employee? o)
            {
                  if (o is Employee employee) return FIO.CompareTo(employee.FIO);
                  else throw new ArgumentException("Некорректное значение параметра");
             }
            public override string ToString()
            {
                return new string($"ФИО: {FIO}\n" +
                    $"Возраст: {Age}\n");
            }
        }
    
    
}
