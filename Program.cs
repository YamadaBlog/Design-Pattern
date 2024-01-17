using System.Threading;

namespace Design_Pattern
{
    internal class Program
    {

        static void Main(string[] args)
        {
            File f1 = new File("test",450);
            File f2 = new File("eze", 550);
            File f3 = new File("teszeaet", 750);
            File f4 = new File("teazeest", 050);

            Folder d1 = new Folder("test5") ;
            d1.Add(f1);
            d1.Add(f2);
            d1.Add(f3);
            d1.Add(f4);

            d1.Display(0);
        }
    }

    internal abstract class Component
    {
        public string name;
        protected Component(string name) {
            this.name = name; 
        }
        public string Operation(string test)
        {
            return test;
        }

        // Abtsract oblige les classes qui héritent d'implémenter la méthode avec abstract
        public abstract void Display(int deep);
        public abstract int Size();
    }

    internal class File : Component
    {
        public int size;
        public File(string name, int size) : base(name) { this.size = size; }
        // Override est lié a abstract 
        public override void Display(int deep)
        {
            Console.WriteLine(new string(' ', deep*2) + name + " {" +Size()+"]");
        }
        public override int Size()
        {
            return this.size;
        }
}
    internal class Folder : Component
    {
        List<Component> Children = new List<Component>();
        public Folder(string name) : base(name) {}

        public override void Display(int deep)
        {
            Console.WriteLine(new string(' ', deep * 2) + name + " {" + Size() + "]");
            foreach(Component child in Children)
            {
                child.Display(deep+1);
            }
        }
        public override int Size()
        {
            int size = 0;
            foreach(Component child in Children)
            {
                size += child.Size();
            }
            return size;
        }
        public void Add(Component child)
        {
            Children.Add(child); 
        }
    }
}