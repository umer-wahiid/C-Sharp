// See https://aka.ms/new-console-template for more information



namespace ConsoleApp4
{
    public class program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Your Name: ");
            //string n = Console.ReadLine();

            //Console.WriteLine("Your Father Name: ");
            //string fn = Console.ReadLine();

            //Console.WriteLine("Your Age: ");
            //string age = Console.ReadLine();

            //Console.WriteLine("Your Phone: ");
            //string num = Console.ReadLine();

            //Console.WriteLine("Your Address: ");
            //string add = Console.ReadLine();

            ////partial p = new partial();
            ////Console.WriteLine(p.b);
            ////Console.WriteLine(p.a);
            ////Static.xyz();
            ////variables v = new variables();
            ////Console.WriteLine(v.cl1);
            ////v.intr = 555;
            ////Console.WriteLine(v.intr);
            ////v.abc();
            ////Console.WriteLine(variables.stat);
            ////variables.xyz();
            ////Console.WriteLine(Static.c);
            polymorphism pol = new polymorphism();
            //Console.WriteLine(pol.data(n,fn));
            //pol.add(5,6);
            Console.WriteLine(pol.calc(10.10,10));
            Console.WriteLine(pol.calc(4.2));

            minus minus = new minus();
            Console.WriteLine(minus.calc(10, 10));
            minus multiply = new multiply();
            Console.WriteLine(multiply.calc(10, 10));


            encapsulation enc = new encapsulation("maaz","22");
            enc.propfunc = "Umer";
            enc.propfunc2 = 21;
            Console.WriteLine(enc.propfunc + " is " + enc.propfunc2 + " years old");

            Console.WriteLine(enc.prop("ayan","2"));

            absdivide div = new absdivide();
            absminus min = new absminus();
            absmulti mul = new absmulti();
            abstract2 abs2 = new abstract2();

            Console.WriteLine(abs2.cal(5, 5));
            Console.WriteLine(min.cal(5, 5));
            Console.WriteLine(mul.cal(5, 5));
            Console.WriteLine(div.cal(5, 5));

        }
    }
}


////Console.WriteLine("Which Table Do You Want");
////int tabnum = int.Parse(Console.ReadLine());


////Console.WriteLine("First Number");
////int firstnum = int.Parse(Console.ReadLine());


////Console.WriteLine("Last Number");
////int endnum = int.Parse(Console.ReadLine());

//if (firstnum <= endnum)
//{
//  for (int a = firstnum; a <= endnum; a++)
//{
//  Console.WriteLine(tabnum + " x " + a + "=" + (tabnum * a));
//}
//}
//else
//{
//  for (int a = firstnum; a >= endnum; a--)
//{
//  Console.WriteLine(tabnum + " x " + a + "=" + (tabnum * a));
//}
//}

//int a = firstnum;
//if (firstnum <= endnum)
//{
//   while (a <= endnum)
// {
//   Console.WriteLine(tabnum + " x " + a + "= " + (tabnum * a));
// a++;
//}
//}
//else
//{
//  while (a >= endnum)
//{
//  Console.WriteLine(tabnum + " x " + a + "= " + (tabnum * a));
//a--;
// }
//}


//if (firstnum <= endnum) { 
//    do
//    {
//        Console.WriteLine(tabnum + " x " + a + "= " + (tabnum * a));
//        a++;
//    }
//    while (a <= endnum);
//}
//else
//{
//    do
//    {
//        Console.WriteLine(tabnum + " x " + a + "= " + (tabnum * a));
//        a--;
//    }
//    while (a >= endnum);




//int n = 20;
//while (n >= 1)
//{ 
//    Console.WriteLine(n);
//    n--;
//    if (n == 4)
//    {
//        break;
//    }
//}













