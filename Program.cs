// множественное наследование
// Math.Round (int x, 2) для округления дробных чисел, вторая позиция - это кол-во знаков после точки.
// sealed *public sealed void NAME* - запрещает наследования от родителя
// override *public override void NAME*  - перегрузка метода от родителя
// названия интерфесов принято начинать с I 

namespace PV113_s_sh
{

    /* abstract class Human
     {
         protected int Id { get; set; }
         protected string FN { get; set; }
         protected string LN { get; set; }
         public Human(int _Id, string _FN, string _LN)
         {
             Id = _Id;
             FN = _FN;
             LN = _LN;
         }
         public virtual void Print()
         {
             Console.WriteLine($" {Id} {FN} {LN} ");
         }
         public override string ToString()
         {
             return $" {Id} {FN} {LN}  ";
         }

         public abstract void Work();
         public abstract void Sleep_();
     }

     abstract class Employee : Human
     {
         public double Salary { get; set; }
         public Employee(int _Id, string _FN, string _LN, double _Salary) : base(_Id, _FN, _LN)
         {
             Salary = _Salary;
         }
         public override string ToString()
         {
             return $" {Id} {FN} {LN} {Salary} ";
         }

         public override void Work()
         {
             Console.WriteLine("Employee-work");
         }

         public override void Sleep_()
         {
             Console.WriteLine("Employee-sleep");
         }
         //public override void Print()
         //{
         //    base.Print();
         //    Console.WriteLine($"{Salary}");
         //}
         //public abstract void Meet_();

     }

     class Driver : Employee
     {
         public string Category { get; set; }
         public Driver(int _Id, string _FN, string _LN, double _Salary,
             string _Category) : base(_Id, _FN, _LN, _Salary)
         {
             Category = _Category;
         }
         public override void Print()
         {
             base.Print();
             Console.WriteLine($"Category -  {Category}");
         }
         public override string ToString()
         {
             return $" {Id} {FN} {LN} {Salary} {Category} ";
         }

         public void Driver_show()
         {
             Console.WriteLine("Driver show");
         }

         */
    /*
     }
     class Manager : Employee
     {
         public string Activity { get; set; }
         public Manager(int _Id, string _FN, string _LN, double _Salary,
             string _Activity) : base(_Id, _FN, _LN, _Salary)
         {
             Activity = _Activity;
         }
         //public override void Print()
         //{
         //    base.Print();
         //    Console.WriteLine($"Activity -  {Activity}");
         //}
         public override string ToString()
         {
             return $" {Id} {FN} {LN} {Salary} {Activity} ";
         }

         public void Manager_show()
         {
             Console.WriteLine("Manager show");
         }
     }

     class IT : Employee
     {
         public string Language { get; set; }
         public IT(int _Id, string _FN, string _LN, double _Salary,
             string _Language) : base(_Id, _FN, _LN, _Salary)
         {
             Language = _Language;
         }
         public override void Print()
         {
             base.Print();
             Console.WriteLine($"Language -  {Language}");
         }
         public override string ToString()
         {
             return $" {Id} {FN} {LN} {Salary} {Language} ";
         }
         public void IT_show()
         {
             Console.WriteLine("IT show");
         }
     }

     class Programe
     {
         public static void Main()
         {
             // Employee e1 = new Employee(1, "FN_1", "LN_1", 1000.0);
             Driver d1 = new Driver(2, "FN_2", "LN_2", 2000.0, "ABC");
             Manager m1 = new Manager(3, "FN_3", "LN_3", 3000.0, "computers");
             IT it1 = new IT(4, "FN_4", "LN_4", 10000.0, "C#");

             Employee[] empl = { d1, m1, it1 };

             foreach (Employee item in empl)
             {
                 //item.Print();
                 Console.WriteLine(item);


                 Console.WriteLine("*********************************");

                 //1 явное приведение к необходимому типу

                 try
                 {
                     ((Driver)item).Driver_show();
                 }
                 catch (Exception)
                 {

                 }

                 //2 as - принудительное приведение к определённому типу

                 Manager m2 = item as Manager;
                 if (m2 != null)
                 {
                     m2.Manager_show();
                 }
                 Console.WriteLine("*********************************");

                 // 3 - is вместе с as\\ через is можно ли данные привести к какому-либо типу

                 if (item is IT)
                 {
                     (item as IT).IT_show();
                 }

                 // protected Object MemberwiseClone(); - поверхностное копирование всего кроме ссылок

                 //Console.WriteLine(d1.GetType().FullName); // выводит полное имя объекта
                 //Console.WriteLine(d1.GetType().IsAbstract); // 
                 //Console.WriteLine(d1.GetType().IsClass); // является ли участником класса
                 //Console.WriteLine(d1.GetType().IsVisible); // можно ли получить доступ к объекту за пределами сборки
             }

         }
     }*/

    /*interface Interface // модификатор доступа по умолчанию public и у всех методов также
    {
        // в С# множественного наследования нет, есть реализция интерфейса
        void Print_1();
        void Print_2();
        public string FN { get; set; }
        event EventHandler WE;
    }

    class MyClass : Interface
    {
        public string FN { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler WE;

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void Print_1()
        {
            throw new NotImplementedException();
        }

        public void Print_2()
        {

        }
    }*/

    abstract class Human
    {
        public int Id { get; set; }
        public string FN { get; set; }
        public string LN { get; set; }
        public DateTime BD { get; set; }

        public override string ToString()
        {
            return $" {Id} {FN} {LN} {BD.ToShortDateString()} ";
        }

    }

    abstract class Employee : Human
    {
        public double Salary { get; set; }

        public string Position { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"{Position} {Salary}";
        }
    }

    interface IWorker
    {
        bool IsWorking { get; }

        string Work();

    }

    interface IManager
    {
        List<IWorker> Workers { get; set; }
        void Control();
        void Organize();
    }

    class Director : Employee, IManager // класс наследуем, интерфейсы реализуем
    {
        public List<IWorker> Workers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Control()
        {
            Console.WriteLine("Директор организовывает работников");
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Organize()
        {
            Console.WriteLine("Директор контролирует бизнес");
        }
    }

    class Driver : Employee, IWorker
    {
        public string Category { get; set; }

        bool isWorker = true;

        public bool IsWorking
        {
            get { return isWorker; }

        }

        public override string ToString()
        {
            return base.ToString() + $"{Category}";
        }

        public string Work()
        {
            return "Развосит продукцию ";
        }
    }

    class IT : Employee, IWorker
    {
        public string Language { get; set; }

        bool isWorker = false;
        public bool IsWorking
        {
            get { return IsWorking; }

        }

        public override string ToString()
        {
            return base.ToString() + $"{Language}";
        }

        public string Work()
        {
            return "Пишет код ";
        }

        class Programm
        {
            public static void Main()
            {
                Director d = new Director { Id = 1, FN = "FN_d", LN = "LN_d", BD = new DateTime(2000, 5, 13), Salary = 100000, Position = "Director" };
                IWorker dr = new Driver { Id = 3, FN = "FN_dr", LN = "LN_dr", BD = new DateTime(1990, 2, 23), Salary = 8000, Position = "Driver", Category = "ABC"  };

               /* if (dr is Employee) 
                { 
                    Console.WriteLine($"{(dr as Employee).Salary }");
                }*/

                // d.Workers.Add(dr);
                d.Workers = new List<IWorker> { dr, new IT { Id = 4, FN = "FN_IT", LN = "LN_IT", BD = new DateTime(2005, 7, 18), Salary = 80000, Position = "IT", Language = "C#" } };

                Console.WriteLine(d);
                Console.WriteLine("**************************");
                if (d is IManager) d.Control();
                foreach (IWorker item in d.Workers)
                {
                    Console.WriteLine(item);

                    if (item.IsWorking)
                    {
                        Console.WriteLine(item.Work());
                    }
                    Console.WriteLine("************************");
                }

            }
        }

    }
}




