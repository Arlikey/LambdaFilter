namespace LambdaFilter
{
    /*internal class Program
    {
        public delegate bool IsOdd(int x);
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Print(Filter(array, Odd));

            Print(Filter(array, delegate (int x)
            {
                return x % 2 != 0;
            }
            ));

            Print(Filter(array, x => x % 2 != 0));


        }

        public static bool Odd(int x)
        {
            return x % 2 != 0;
        }

        public static int[] Filter(int[] array, IsOdd isOdd)
        {
            int[] newArray = new int[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (isOdd(array[i]))
                {
                    Array.Resize(ref newArray, newArray.Length + 1);
                    newArray[newArray.Length - 1] = array[i];
                }
            }
            return newArray;

        }

        public static void Print(int[] array)
        {
            Array.ForEach(array, x => { Console.Write(x + " "); });
            Console.WriteLine();
        }
    }*/

    /*public class AdditionalTask1
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product {Name = "Orange", Price = 7.99m, Rating = 9.5f},
                new Product {Name = "Apple", Price = 4.50m, Rating = 10f},
                new Product {Name = "Banana", Price = 6.59m, Rating = 8.3f},
                new Product {Name = "Kiwi", Price = 10.0m, Rating = 7.7f},
            };
            
            Category category = new Category("Fruits", products);

            User user = new User("Bob", "password", new Basket(products));

            user.Basket.Info();

            user.Basket.Add(new Product { Name = "Bread", Price = 2.99m, Rating = 9.99f });
            user.Basket.Info();
        }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public float Rating { get; set; }

            public override string ToString()
            {
                return $"Name - {Name}, Price - {Price}, Rating - {Rating}";
            }
        }

        public class Category
        {
            public string Name { get; set; }
            private Product[] products;

            public Category(string name, Product[] products)
            {
                Name = name;
                this.products = products;
            }

            public void Info()
            {
                Console.WriteLine($"{Name}:");
                Array.ForEach(products, product => Console.WriteLine($"\t{product}"));
            }
        }

        public class Basket
        {
            public delegate void BasketDelegate(Product product);
            public event BasketDelegate BasketHandler;

            private Product[] purchasedProducts;

            public Basket(Product[] purchasedProducts)
            {
                this.purchasedProducts = purchasedProducts;
            }

            public void Info()
            {
                Console.WriteLine($"Purchased Goods:");
                Array.ForEach(purchasedProducts, product => Console.WriteLine($"\t{product}"));
            }

            public void Add(Product purchasedProduct)
            {
                Array.Resize(ref purchasedProducts, purchasedProducts.Length + 1); 
                purchasedProducts[purchasedProducts.Length-1] = purchasedProduct;
                BasketHandler?.Invoke(purchasedProduct);
            }
        }

        public class User
        {
            public User(string name, string password, Basket basket)
            {
                Name = name;
                Password = password;
                Basket = basket;
                Basket.BasketHandler += Basket_BasketHandler;
            }

            private void Basket_BasketHandler(Product product)
            {
                Console.WriteLine($"В корзину был добавлен товар: {product.Name}");
            }

            public string Name { get; set; }
            public string Password { get; set; }
            public Basket Basket { get; set; }
        }

    }*/

    /*public class AdditionalTask3
    {
        public delegate void CountStudents(Student[] students);
        static void Main(string[] args)
        {

            Student[] students = new Student[1234];

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student();
            }

            CountStudents countStudents = (Student[] students) =>
            {
                int bornInWinter = 0, bornInSpring = 0, bornInAutumn = 0, bornInSummer = 0;
                foreach(Student student in students)
                {
                    if(student.Birthday.Month >= 12 || student.Birthday.Month <= 2)
                    {
                        bornInWinter++;
                    }
                    else if (student.Birthday.Month >= 3 && student.Birthday.Month <= 5)
                    {
                        bornInSpring++;
                    }
                    else if (student.Birthday.Month >= 6 && student.Birthday.Month <= 8)
                    {
                        bornInSummer++;
                    }
                    else
                    {
                        bornInAutumn++;
                    }
                }
                Console.WriteLine($"""
                    Студентов родившихся зимой: {bornInWinter}
                    Студентов родившихся весной: {bornInSpring}
                    Студентов родившихся летом: {bornInSummer}
                    Студентов родившихся осенью: {bornInAutumn}
                    """);
            };

            countStudents(students);
        }

        public class Student
        {
            public Student()
            {
                Birthday = start.AddDays(random.Next(range));
            }
            private static Random random = new Random();
            private static DateTime start = new DateTime(1995, 1, 1);
            private int range = (DateTime.Today - start).Days;
            public DateTime Birthday { get; set; }
        }
    }*/

    /*public class AdditionalTask4
    {
        public delegate char Delegate();
        static void Main(string[] args)
        {
            Class a = new Class("Hello World!", true);
            Class b = new Class("Hello World!", false);

            Console.WriteLine(a.Handler());
            Console.WriteLine(b.Handler());
        }

        public class Class
        {
            public string text;
            private Delegate handler;

            public Class(string text, bool handlerType)
            {
                this.text = text;
                if (handlerType)
                {
                    handler = () => text.First();
                }
                else
                {   
                    handler = () => text.Last();
                }
            }

            public Delegate Handler { get => handler; }
        }
    }*/

    /*public class AdditionalTask5
    {
        public delegate int CreateNumber(int number);
        static void Main(string[] args)
        {
            CreateNumber createNumber = (number) =>
            {
                string newNumber = number.ToString();
                char leftDigit = newNumber[0];
                newNumber = newNumber.Remove(0, 1);

                newNumber += leftDigit;

                return int.Parse(newNumber);
            };

            Console.WriteLine(createNumber(123));
        }
    }*/

    /*public class AdditionalTask6
    {
        enum DaysOfWeek
        {
            Monday = 1,
            Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }

        public delegate string GetDayOfWeek();

        static void Main(string[] args)
        {
            int day = 1;
            DaysOfWeek days = (DaysOfWeek)day;
            GetDayOfWeek getDayOfWeek = () => { if (days == (DaysOfWeek)8) days = (DaysOfWeek)1; return days++.ToString(); };

            for (int i = 0; i < 14;  i++)
            {
                Console.WriteLine(getDayOfWeek());
            }
        }


    }*/

    /*public class AdditionaslTask7
    {
        static void Main(string[] args)
        {
            string[] strings =
            {
                "Hello",
                "123",
                "1234",
                "321",
                "2454653"
            };

            IEnumerable<string> sortedString = strings.OrderBy(str => str.Length);

            foreach (string str in sortedString)
            {
                Console.WriteLine(str);
            }
        }

        
    }*/
}
